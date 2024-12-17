using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using Xceed.Words.NET;
using PdfiumViewer;
using PdfSharp_gdi = PdfSharp.Pdf;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace ChuKySoSchnorr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        // A simple method to evaluate
        // Euler Totient Function
        private int phi(int n)
        {
            int result = 1;
            for (int i = 2; i < n; i++)
                if (gcd(i, n) == 1)
                    result++;
            return result;
        }
        private List<int> PrimitiveRootCheck(int mod)
        {
            List<OrdInfo> orderList = getOrderList(mod);
            //int fi = phi(mod);
            //int pr = phi(fi);
            List<int> primitiveRoots = findPrimitiveRoots(orderList);

            return primitiveRoots;
        }
        private List<int> findPrimitiveRoots(List<OrdInfo> orderList)
        {
            List<int> primitiveRoots = new List<int>();
            foreach (OrdInfo n in orderList)
            {
                if (n.primitive)
                {
                    primitiveRoots.Add(n.x);
                }
            }

            return primitiveRoots;
        }
        private List<int> completeFactors(int n)
        {
            List<int> factors = new List<int>();
            int x = Math.Abs(n);

            for (var i = 1; i <= x; i++)
            {
                if (x % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }
        private int order(int a, int m)
        {
            int fi = phi(m);
            List<int> factors = completeFactors(fi);

            var answer = 0;
            BigInteger temp = 0;

            foreach (int i in factors)
            {

                temp = BigInteger.ModPow(a, i, m);

                if (temp == 1)
                {
                    answer = i;
                    return answer;
                }
            }
            return answer;
        }
        private List<OrdInfo> getOrderList(int mod)
        {
            List<OrdInfo> ordList = new List<OrdInfo>();
            int fi = phi(mod);
            int ord;
            for (int i = 1; i < mod; i++)
            {
                ord = order(i, mod);
                bool primitive;

                if (ord == fi)
                {
                    primitive = true;
                }
                else
                {
                    primitive = false;
                }
                ordList.Add(new OrdInfo(i, primitive));
            }
            return ordList;
        }

        private static string SHA256_String(string s)
        {
            var byteString = Encoding.UTF8.GetBytes("key");
            using (SHA256 sha256 = SHA256.Create())
            {
                StringBuilder hash = new StringBuilder();
                byte[] hashArray = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
                foreach (byte b in hashArray)
                {
                    hash.Append(b.ToString("x"));
                }
                return hash.ToString();
            }
        }

        public static BigInteger SHA256_Hex(string message)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                string hashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower(); // Chuyển thành chuỗi hexa
                return BigInteger.Parse("0" + hashHex, System.Globalization.NumberStyles.HexNumber); // Chuyển thành BigInteger
            }
        }

        private List<int> findDivisor(int n)
        {
            List<int> array = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    array.Add(i);
                }
            }
            return array;
        }
        private static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;

            if (n == 2)
                return true; // 2 là số nguyên tố duy nhất

            if (n % 2 == 0)
                return false; // Các số chẵn (ngoại trừ 2) không phải là số nguyên tố

            // Kiểm tra từ 3 đến căn bậc hai của n
            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false; // Nếu n chia hết cho i thì không phải số nguyên tố
            }

            return true;
        }
        private bool validate(int p, int q, int g, int x)
        {
            // uoc cua p
            string divisor = "";
            divisor = System.String.Join(",", findDivisor(p - 1));
            List<int> divisor_list = findDivisor(p - 1);

            // nguyen thuy cua p
            string primitive = "";
            primitive = System.String.Join(", ", PrimitiveRootCheck(p));
            if (!IsPrime(p))
            {
                errorMsg.Text = "p phải là số nguyên tố";
                return false;
            }
            else if (!divisor_list.Contains(q))
            {
                errorMsg.Text = "q phải là ước của " + (p - 1) + " gồm {" + divisor + "}";
                return false;
            }
            else if (!PrimitiveRootCheck(p).Contains(g))
            {
                errorMsg.Text = "g phải là nguyên thủy của " + (p) + " gồm {" + primitive + "}";
                return false;
            }
            else if (x < 0 || x > q - 1)
            {
                errorMsg.Text = "x phải khoảng [0, q-1]";
                return false;
            }
            txtY.Text = "";
            errorMsg.Text = "";
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(txtP.Text);
                int q = int.Parse(txtQ.Text);
                int g = int.Parse(txtG.Text);
                int x = int.Parse(txtX.Text);

                if (validate(p, q, g, x))
                {
                    //txtY.Text = Convert.ToString(Math.Pow(g, x) % p);
                    txtY.Text = BigInteger.ModPow(g, x, p).ToString();
                }
            }
            catch (Exception ex)
            {
                errorMsg.Text = ex.Message;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(txtP.Text);
                int g = int.Parse(txtG.Text);
                int q = int.Parse(txtQ.Text);
                int x = int.Parse(txtX.Text);

                BigInteger hm = SHA256_Hex(txtMGenerate.Text);

                Random random = new Random();
                int k = random.Next((q - 1) - 2 + 1) + 2;
                if (txtP.Text != "")
                {
                    txtKSign.Text = Convert.ToString(k);
                }
                BigInteger r = BigInteger.ModPow(g, k, p);
                txtRSign.Text = Convert.ToString(r);
                BigInteger s = (k - x * (1 / r) * hm) % q;
                if (s < 0)
                {
                    s += q;  // Điều chỉnh để đảm bảo s không âm
                }
                txtSSign.Text = Convert.ToString(s);
                txtSign.Text = "(" + r + ", " + s + ")";
                txtMCheck.Text = txtMGenerate.Text;
            }
            catch (Exception ex)
            {
                errorMsg.Text = ex.Message;
            }
        }
        private int modInverse(int A, int M)
        {
            if (gcd(A, M) == 1)
            {
                for (int X = 1; X < M; X++)
                    if (((A % M) * (X % M)) % M == 1)
                        return X;
            }
            //errorMsg.Text = "r va q phai la 2 so nguyen to cung nhau !";
            return 0;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(txtP.Text);
                int r = int.Parse(txtRCheck.Text);
                int s = int.Parse(txtSCheck.Text);
                int q = int.Parse(txtQ.Text);
                int g = int.Parse(txtG.Text);
                int y = int.Parse(txtY.Text);
                int k = int.Parse(txtKSign.Text);
                int x = int.Parse(txtX.Text);

                BigInteger hm = SHA256_Hex(txtMGenerate.Text);
                //BigInteger gs = (BigInteger.ModPow(g, s, p) * BigInteger.ModPow(y, hm, p)) % p;
                //BigInteger ev = SHA256_Hex(gs.ToString());

                //BigInteger u1 = s;
                //BigInteger u2 = hm;

                //BigInteger gu1 = BigInteger.ModPow(g, u1, p);
                //BigInteger yu2 = BigInteger.ModPow(y, u2, p);

                //BigInteger v1 = (gu1 * yu2) % p;
                //BigInteger v2 = r % p;

                //double u1 = (s * (1 / r)) % q;
                //double u2 = (double)((hm * (1 / r)) % q);

                //double v = (Math.Pow(g, u1) * Math.Pow(y, u2)) % q;

                BigInteger u1 = ((s % q) * modInverse(r, q)) % q;
                BigInteger u2 = ((hm % q) * modInverse(r, q)) % q;
                BigInteger v = (BigInteger.ModPow(g, u1, p) * BigInteger.ModPow(y, u2, p)) % p;

                //txtCheckResult.Text = "v: " + v + ", r: " + r;
                //return;

                if (v == r)
                {
                    txtCheckResult.Text = "Chữ ký hợp lệ :))";
                }
                else
                {
                    txtCheckResult.Text = "Chữ ký giả mạo :))";
                }
            }
            catch (Exception ex)
            {
                errorMsg.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx)|*.docx",
                Title = "Open Text or Word File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = string.Empty;

                if (Path.GetExtension(filePath).ToLower() == ".txt")
                {
                    fileContent = File.ReadAllText(filePath);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".docx")
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        fileContent = document.Text;
                    }
                }
                txtMGenerate.Text = fileContent;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                //Filter = "Text Files (*.txt)|*.txt|Word Documents (*.docx)|*.docx",
                Title = "Open Text or Word File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileContent = string.Empty;

                string extension = Path.GetExtension(filePath).ToLower();
                if (extension == ".txt")
                {
                    fileContent = File.ReadAllText(filePath);
                }
                else if (extension == ".docx")
                {
                    using (DocX document = DocX.Load(filePath))
                    {
                        fileContent = document.Text;
                    }
                }
                txtMCheck.Text = fileContent;
            }
        }
    }
}
