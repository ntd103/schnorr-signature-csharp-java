using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace schnorr_signature_scheme_csharp
{
    public partial class testme : Form
    {
        // Variables for keys and signatures
        private BigInteger p, q, g, y, a;
        private BigInteger b, k; // Added 'b' and 'k' as class variables
        private BigInteger s, eSig;
        private string message;

        public testme()
        {
            InitializeComponent();
        }

        private bool MillerRabinTest(BigInteger num, int k)
        {
            if (num <= 1) return false;
            if (num <= 3) return true;
            if (num.IsEven) return false;

            BigInteger r = 0, q = num - 1;
            while (q.IsEven)
            {
                q /= 2;
                r++;
            }

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[num.ToByteArray().LongLength];
                for (int i = 0; i < k; i++)
                {
                    rng.GetBytes(bytes);
                    BigInteger aRand = new BigInteger(bytes) % (num - 3) + 2;
                    BigInteger x = BigInteger.ModPow(aRand, q, num);
                    if (x == 1 || x == num - 1) continue;

                    bool pass = false;
                    for (int j = 1; j < r; j++)
                    {
                        x = BigInteger.ModPow(x, 2, num);
                        if (x == num - 1)
                        {
                            pass = true;
                            break;
                        }
                    }

                    if (!pass) return false;
                }
            }

            return true;
        }

        private BigInteger ComputeHash(string message, BigInteger r)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string combined = message + r.ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);
                Array.Reverse(hash); // Ensure little endian for BigInteger
                hash = hash.Concat(new byte[] { 0 }).ToArray(); // Ensure positive
                return new BigInteger(hash);
            }
        }

        private BigInteger GenerateFactorOf(BigInteger n)
        {
            // Simple method to find a prime factor of n
            for (BigInteger i = 2; i <= Sqrt(n); i++)
            {
                if (n % i == 0 && MillerRabinTest(i, 5))
                    return i;
            }
            return -1;
        }

        private BigInteger Sqrt(BigInteger n)
        {
            if (n < 0) throw new ArgumentException("Negative argument.");
            if (n == 0) return 0;
            BigInteger a = 1;
            BigInteger b = n;
            while (a <= b)
            {
                BigInteger mid = (a + b) / 2;
                BigInteger midSquared = mid * mid;
                if (midSquared == n)
                    return mid;
                if (midSquared < n)
                    a = mid + 1;
                else
                    b = mid - 1;
            }
            return b;
        }

        private BigInteger GenerateRandom(BigInteger min, BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger result;
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                do
                {
                    rng.GetBytes(bytes);
                    result = new BigInteger(bytes);
                }
                while (result < min || result > max);
            }
            return BigInteger.Abs(result);
        }

        private BigInteger GenerateLargePrime(int bits)
        {
            while (true)
            {
                BigInteger prime = GenerateRandom(BigInteger.One << (bits - 1), (BigInteger.One << bits) - 1);
                if (MillerRabinTest(prime, 10))
                    return prime;
            }
        }

        private bool IsPrime(BigInteger value)
        {
            if (value < 2) return false;
            if (value == 2 || value == 3) return true;
            if (value.IsEven) return false;
            return MillerRabinTest(value, 10);
        }

        private void GeneratePublicKey()
        {
            // Step 1: Choose large primes p and q such that q | (p-1)
            do
            {
                p = GenerateLargePrime(512);
                q = GenerateFactorOf(p - 1);
            } while (q == -1);

            // Step 2: Choose random b from Z_p^*
            do
            {
                b = GenerateRandom(2, p - 2);
                g = BigInteger.ModPow(b, (p - 1) / q, p);
            } while (g == 1);

            // Step 3: Choose secret key a from Z_q
            a = GenerateRandom(1, q - 1);

            // Step 4: Compute public key y = g^a mod p
            y = BigInteger.ModPow(g, a, p);

            // Display values
            txtPrimeP.Text = p.ToString();
            txtPrimeQ.Text = q.ToString();
            txtB.Text = b.ToString();
            txtA.Text = a.ToString();
            txtGValue.Text = g.ToString();
            txtYValue.Text = y.ToString();
            txtPublicKey.Text = $"(p: {p}, q: {q}, g: {g}, y: {y})";

            MessageBox.Show("Tạo khóa thành công");
        }

        private void GenerateSignature()
        {
            // Ensure message is loaded
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Không bỏ trống thông điệp m");
                return;
            }

            // Ensure k is valid
            if (!BigInteger.TryParse(txtK.Text, out k) || k < 1 || k >= q)
            {
                MessageBox.Show("Giá trị k không hợp lệ");
                return;
            }

            // Compute r = g^k mod p
            BigInteger r = BigInteger.ModPow(g, k, p);

            // Compute e = h(m || r)
            eSig = ComputeHash(message, r);

            // Compute s = (a * e + k) mod q
            s = (a * eSig + k) % q;

            // Display s, e, and signature
            txtSValue.Text = s.ToString();
            txtEValue.Text = eSig.ToString();
            txtSignature.Text = $"(s: {s}, e: {eSig})";

            MessageBox.Show("Tạo chữ ký thành công");
        }

        private bool VerifySignatureMethod(string messageVerify, BigInteger sVerify, BigInteger eVerify, BigInteger yVerify)
        {
            // Compute v = g^s * y^(-e) mod p
            BigInteger yInv = ModInverse(yVerify, p);
            if (yInv == -1)
                return false;

            BigInteger v = (BigInteger.ModPow(g, sVerify, p) * BigInteger.ModPow(yInv, eVerify, p)) % p;

            // Compute e' = h(m || v)
            BigInteger ePrime = ComputeHash(messageVerify, v);

            // Compare e' and e
            return ePrime == eVerify;
        }

        private void BtnGenerateP_Click(object sender, EventArgs e)
        {
            p = GenerateLargePrime(512);
            txtPrimeP.Text = p.ToString();
        }

        private void BtnGenerateQ_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(txtPrimeP.Text, out BigInteger currentP))
            {
                q = GenerateFactorOf(currentP - 1);
                if (q != -1)
                {
                    txtPrimeQ.Text = q.ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy q thích hợp cho p này");
                }
            }
            else
            {
                MessageBox.Show("Giá trị p không hợp lệ");
            }
        }

        private void BtnGenerateB_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(txtPrimeP.Text, out BigInteger currentP) && IsPrime(currentP))
            {
                b = GenerateRandom(2, currentP - 2);
                txtB.Text = b.ToString();
            }
            else
            {
                MessageBox.Show("Giá trị p không hợp lệ hoặc chưa được tạo khóa");
            }
        }

        private void BtnGenerateA_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(txtPrimeQ.Text, out BigInteger currentQ) && IsPrime(currentQ))
            {
                a = GenerateRandom(1, currentQ - 1);
                txtA.Text = a.ToString();
            }
            else
            {
                MessageBox.Show("Giá trị q không hợp lệ hoặc chưa được tạo khóa");
            }
        }

        private void BtnGenerateK_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(txtPrimeQ.Text, out BigInteger currentQ) && IsPrime(currentQ))
            {
                k = GenerateRandom(1, currentQ - 1);
                txtK.Text = k.ToString();
            }
            else
            {
                MessageBox.Show("Giá trị q không hợp lệ hoặc chưa được tạo khóa");
            }
        }

        private void BtnUploadMessage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtMessagePath.Text = openFileDialog.FileName;
                    message = System.IO.File.ReadAllText(openFileDialog.FileName);
                    txtMessageText.Text = message;
                }
            }
        }

        private void BtnUploadMessageVerify_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtMessageVerifyPath.Text = openFileDialog.FileName;
                    message = System.IO.File.ReadAllText(openFileDialog.FileName);
                    txtMessageVerifyText.Text = message;
                }
            }
        }

        private void BtnCreateKey_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (!BigInteger.TryParse(txtPrimeP.Text, out BigInteger inputP) || !IsPrime(inputP))
            {
                MessageBox.Show("Giá trị tham số p không hợp lệ");
                return;
            }

            if (!BigInteger.TryParse(txtPrimeQ.Text, out BigInteger inputQ) || (inputP - 1) % inputQ != 0 || !IsPrime(inputQ))
            {
                MessageBox.Show("Giá trị tham số q không hợp lệ");
                return;
            }

            if (!BigInteger.TryParse(txtB.Text, out BigInteger inputB) || inputB < 2 || inputB >= inputP)
            {
                MessageBox.Show("Giá trị tham số b không hợp lệ");
                return;
            }

            if (!BigInteger.TryParse(txtA.Text, out BigInteger inputA) || inputA < 1 || inputA >= inputQ)
            {
                MessageBox.Show("Giá trị tham số a không hợp lệ");
                return;
            }

            // Generate public key using provided parameters
            g = BigInteger.ModPow(inputB, (inputP - 1) / inputQ, inputP);
            if (g == 1)
            {
                MessageBox.Show("g không phải phần tử sinh, nhập giá trị b khác");
                return;
            }

            y = BigInteger.ModPow(g, inputA, inputP);

            // Display values
            txtGValue.Text = g.ToString();
            txtYValue.Text = y.ToString();
            txtPublicKey.Text = $"(p: {inputP}, q: {inputQ}, g: {g}, y: {y})";

            // Assign to class variables
            p = inputP;
            q = inputQ;
            b = inputB;
            a = inputA;

            MessageBox.Show("Tạo khóa thành công");
        }

        private void BtnCreateSignature_Click(object sender, EventArgs e)
        {
            // Ensure message is loaded
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Không bỏ trống thông điệp m");
                return;
            }

            // Ensure k is valid
            if (!BigInteger.TryParse(txtK.Text, out k) || k < 1 || k >= q)
            {
                MessageBox.Show("Giá trị k không hợp lệ");
                return;
            }

            // Compute r = g^k mod p
            BigInteger r = BigInteger.ModPow(g, k, p);

            // Compute e = h(m || r)
            eSig = ComputeHash(message, r);

            // Compute s = (a * e + k) mod q
            s = (a * eSig + k) % q;

            // Display s, e, and signature
            txtSValue.Text = s.ToString();
            txtEValue.Text = eSig.ToString();
            txtSignature.Text = $"(s: {s}, e: {eSig})";

            MessageBox.Show("Tạo chữ ký thành công");
        }

        private void BtnVerifySignature_Click(object sender, EventArgs e)
        {
            // Validate public key and signature input
            string publicKeyInput = txtPublicKeyInput.Text;
            string signatureInput = txtSignatureInput.Text;

            var publicKeyParts = publicKeyInput.Split(',');
            if (publicKeyParts.Length != 4 ||
                !BigInteger.TryParse(publicKeyParts[0].Trim(), out BigInteger pVerify) ||
                !BigInteger.TryParse(publicKeyParts[1].Trim(), out BigInteger qVerify) ||
                !BigInteger.TryParse(publicKeyParts[2].Trim(), out BigInteger gVerify) ||
                !BigInteger.TryParse(publicKeyParts[3].Trim(), out BigInteger yVerify))
            {
                MessageBox.Show("Khóa công khai hợp lệ");
                return;
            }

            var signatureParts = signatureInput.Split(',');
            if (signatureParts.Length != 2 ||
                !BigInteger.TryParse(signatureParts[0].Trim(), out BigInteger sVerify) ||
                !BigInteger.TryParse(signatureParts[1].Trim(), out BigInteger eVerify))
            {
                MessageBox.Show("Chữ ký không hợp lệ");
                return;
            }

            string messageVerify = txtMessageVerifyText.Text;
            if (string.IsNullOrEmpty(messageVerify))
            {
                MessageBox.Show("Không bỏ trống thông điệp m");
                return;
            }

            //bool isValid = VerifySignatureMethod(messageVerify, sVerify, eVerify, yVerify);
            //txtVerifyResult.Text = isValid ? "Chữ ký hợp lệ" : "Chữ ký không hợp lệ";
        }

        private BigInteger ModInverse(BigInteger x, BigInteger n)
        {
            return BigInteger.ModPow(x, n - 2, n); // Using Fermat's Little Theorem for inverse
        }
    }
}