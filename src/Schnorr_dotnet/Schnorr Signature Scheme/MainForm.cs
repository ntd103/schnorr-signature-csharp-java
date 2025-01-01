using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Numerics;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace Schnorr_Signature_Scheme
{
    public partial class MainForm : Form
    {
        //Chú ý các component của winform//
        // Panel pnlKeyGen;
        // TextBox txtExportedKeyPath; Hộp chứa đường dẫn file xuất khóa
        // Button btnExportPublicKey; Nút xuất khóa công khai
        // Button btnGenPara; Nút tạo tham số p, q, g, a
        // TextBox txtCreatePublicKeyY; Hộp chứa khóa công khai y trong quá trình tạo khóa
        // TextBox txtPrivateA; Hộp chứa khóa bí mật a
        // TextBox txtG; Hộp chứa phần tử sinh g
        // TextBox txtPrimeQ; Hộp chứa số nguyên tố q
        // TextBox txtPrimeP;  Hộp chứa số nguyên tố p
        // Label lblPublicKeyY;  Nhãn khóa công khai y
        // Label lblPrivateKeyA; Nhãn khóa bí mật a
        // Label lblG;  Nhãn phần tử sinh g
        // Label lblPrimeQ; Nhãn số nguyên tố q
        // Label lblPrimeP; Nhãn số nguyên tố p
        // Label lblKeyGenTitle; 
        // Panel pnlVerify; 
        // TextBox txtVerifyResult; hộp chứa Kết quả xác thực chữ ký
        // Label lblVerifyResult; 
        // Button btnImportPublicKeyY; nút nhập khóa công khai y
        // TextBox txtImportedSignaturePath; hộp chứa đường dẫn file chứa chữ ký
        // Button btnImportSignature; nút nhập chữ ký
        // Button btnVerifySignature;  nút xác thực chữ ký
        // TextBox txtVerifyPublicKeyY; hộp chứa khóa công khai y trong quá trình xác thực
        // TextBox txtVerifyE; hộp chứa eSign trong quá trình xác thực
        // TextBox txtVerifyS; hộp chứa s trong quá trình xác thực
        // TextBox txtVerifyMessageM; hộp chứa thông điệp muốn xác thực
        // TextBox txtVerifyMsgPath; hộp chứa đường dẫn file chứa thông điệp muốn xác thực
        // Button btnImportVerifyMsg; nút nhập thông điệp muốn xác thực
        // Label lblVerifyPublicKeyY;  nhãn khóa công khai y trong quá trình xác thực
        // Label lblSignature; 
        // Label lblVerifyE;
        // Label lblVerifyS;
        // Label lblVerifyMessageM;
        // Label lblVerifyTitle;
        // Panel pnlSign;
        // Button btnCreateSignature; nút tạo chữ ký
        // TextBox txtExportedSignaturePath; hộp chứa đường dẫn file xuất chữ ký
        // TextBox txtSignMessageM; hộp chứa thông điệp muốn ký
        // Button btnExportSignature; nút xuất chữ ký
        // TextBox txtSignE; hộp chứa eSign trong quá trình tạo chữ ký
        // TextBox txtSignS; hộp chứa s trong quá trình tạo chữ ký
        // TextBox txtK; hộp chứa k trong quá trình tạo chữ ký
        // TextBox txtImportedSignMsgPath; hộp chứa đường dẫn file chứa thông điệp muốn ký
        // Button btnImportSignMsg; nút nhập thông điệp muốn ký
        // Label lblSignE; 
        // Label lblSignS;
        // Label lblSignTitle;
        // Label lblK;
        // Label lblSignMessageM;
        // Button btnCreatePublicKey; nút tạo khóa công khai
        // Label lblEnterSignature;
        // TextBox txtImportedPublicKeyPath; hộp chứa đường dẫn file chứa khóa công khai y
        //-----------------------------------------//

        //các tham số sử dụng toàn cục
        private BigInteger p, q, g, a, k, y;
        private readonly int[] smallPrimes = new int[]
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
            31, 37, 41, 43, 47, 53, 59, 61, 67,
            71, 73, 79, 83, 89, 97, 101, 103,
            107, 109, 113, 127, 131, 137, 139,
            149, 151, 157, 163, 167, 173, 179,
            181, 191, 193, 197, 199, 211, 223,
            227, 229, 233, 239, 241, 251, 257,
            263, 269, 271, 277, 281, 283, 293,
            307, 311, 313, 317, 331, 337, 347, 349
        };

        public MainForm()
        {
            InitializeComponent();  
        }

        #region Utility Functions

        // Kiểm tra số nguyên tố bằng Miller-Rabin
        private bool MillerRabinTest(BigInteger n, int k = 20)
        {
            if (n < 2) return false;
            if (n == 2 || n == 3) return true;
            if (n % 2 == 0) return false;

            // Kiểm tra với các số nguyên tố nhỏ
            foreach (int prime in smallPrimes)
            {
                if (n == prime) return true;
                if (n % prime == 0) return false;
            }

            // Tính d và r sao cho n - 1 = d * 2^r
            BigInteger d = n - 1;
            int r = 0;
            while (d % 2 == 0)
            {
                d /= 2;
                r++;
            }

            // Miller-Rabin test
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[n.ToByteArray().Length];
                for (int i = 0; i < k; i++)
                {
                    BigInteger a;
                    do
                    {
                        rng.GetBytes(bytes);
                        bytes[bytes.Length - 1] &= 0x7F; // Đảm bảo số dương
                        a = new BigInteger(bytes) % (n - 3) + 2;
                    } while (a < 2 || a >= n - 1);

                    BigInteger x = ModExp(a, d, n);
                    if (x == 1 || x == n - 1) continue;

                    bool isProbablePrime = false;
                    for (int j = 0; j < r - 1; j++)
                    {
                        x = ModExp(x, 2, n);
                        if (x == n - 1)
                        {
                            isProbablePrime = true;
                            break;
                        }
                        if (x == 1) return false;
                    }
                    if (!isProbablePrime) return false;
                }
            }
            return true;
        }

        // Tính lũy thừa modulo bằng phương pháp bình phương và nhân
        private BigInteger ModExp(BigInteger b, BigInteger e, BigInteger m)
        {
            if (m == 1)
                return 0;

            BigInteger result = 1;
            b = b % m;

            while (e > 0)
            {
                if ((e & 1) == 1)
                    result = (result * b) % m;

                e = e >> 1;
                b = (b * b) % m;
            }

            return result;
        }

        // Thuật toán Euclid mở rộng
        private (BigInteger gcd, BigInteger x, BigInteger y) ExtGCD(BigInteger a, BigInteger b)
        {
            if (a == 0)
                return (b, 0, 1);

            var (gcd, x1, y1) = ExtGCD(b % a, a);
            BigInteger x = y1 - (b / a) * x1;
            BigInteger y = x1;

            return (gcd, x, y);
        }

        // Tạo số nguyên tố ngẫu nhiên có độ dài bit cho trước
        private BigInteger GeneratePrime(int bitLength)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                while (true)
                {
                    byte[] bytes = new byte[bitLength / 8 + 1];
                    rng.GetBytes(bytes);
                    bytes[bytes.Length - 1] &= (byte)0x7F; // Ensure positive number
                    BigInteger candidate = new BigInteger(bytes);
                    
                    // Ensure the number has exactly bitLength bits
                    candidate |= BigInteger.One << (bitLength - 1);
                    
                    // Ensure the number is odd
                    candidate |= BigInteger.One;

                    if (MillerRabinTest(candidate, 20))
                        return candidate;
                }
            }
        }

        // Tính hash SHA-256
        private byte[] ComputeSHA256(byte[] data)
        {
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }

        //Số ngẫu nhiên trong Zp*
        private BigInteger RandomNumInZpStar(BigInteger p)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                while (true)
                {
                    byte[] bytes = new byte[p.ToByteArray().Length];
                    rng.GetBytes(bytes);
                    BigInteger num = new BigInteger(bytes);
                    num = num % (p - 1);
                    if (num > 1 && ExtGCD(num, p).gcd == 1)
                        return num;
                }
            }
        }

        private BigInteger RandomNumInZq(BigInteger q)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                while (true)
                {
                    byte[] bytes = new byte[q.ToByteArray().Length];
                    rng.GetBytes(bytes);
                    bytes[bytes.Length - 1] &= 0x7F; // Đảm bảo số dương
                    BigInteger num = new BigInteger(bytes);
                    BigInteger result = (num % (q - 1)) + 1;
                    if (result > 0 && result < q)
                        return result;
                }
            }
        }

        private BigInteger ComputeHash(byte[] message, BigInteger number, BigInteger q)
        {
            using (var sha256 = SHA256.Create())
            {
                // Nối message và number
                byte[] numberBytes = number.ToByteArray();
                byte[] concatenated = new byte[message.Length + numberBytes.Length];
                Buffer.BlockCopy(message, 0, concatenated, 0, message.Length);
                Buffer.BlockCopy(numberBytes, 0, concatenated, message.Length, numberBytes.Length);
                
                // Tính hash và chuyển thành BigInteger
                byte[] hashBytes = sha256.ComputeHash(concatenated);
                BigInteger hash = new BigInteger(hashBytes);
                
                // Đảm bảo kết quả dương và trong Zq
                BigInteger result = hash % q;
                if (result < 0) result += q;
                return result;
            }
        }

        #endregion

        #region Parameter Generation Functions

        // Tạo số nguyên tố p, q
        private void GenerateLargePrimes()
        {
            // Generate q first (160 bits is standard for DSA)
            q = GeneratePrime(160);

            // Generate p (1024 bits is standard for DSA)
            int pBitLength = 1024;
            BigInteger multiplier = BigInteger.One;
            while (true)
            {
                // p = kq + 1 for some k
                BigInteger p_candidate = multiplier * q + 1;
                if (p_candidate.ToByteArray().Length * 8 > pBitLength)
                {
                    // Start over with a new q if we exceeded the desired bit length
                    q = GeneratePrime(160);
                    multiplier = BigInteger.One;
                    continue;
                }
                
                if (MillerRabinTest(p_candidate, 20))
                {
                    p = p_candidate;
                    break;
                }
                multiplier++;
            }

            txtPrimeP.Text = p.ToString();
            txtPrimeQ.Text = q.ToString();
        }

        // Tạo phần tử sinh g
        private void GenerateG()
        {
            do
            {
                BigInteger h = RandomNumInZpStar(p);
                g = ModExp(h, (p - 1) / q, p);
            } while (g <= 1);

            txtG.Text = g.ToString();
        }

        #endregion

        #region Schnorr Signature Scheme Functions

        // Tạo khóa công khai
        private void GeneratePublicKey()
        {
            // Private key a is already set
            if (string.IsNullOrEmpty(txtPrivateA.Text))
                return;

            a = BigInteger.Parse(txtPrivateA.Text);
            y = ModExp(g, a, p);
            txtCreatePublicKeyY.Text = y.ToString();
        }

        // Tạo chữ ký
        private (BigInteger s, BigInteger eSign) GenerateSignature()
        {
            if (string.IsNullOrEmpty(txtSignMessageM.Text))
                return (0, 0);

            // Generate random k
            k = RandomNumInZq(q);
            txtK.Text = k.ToString();

            // Calculate r = g^k mod p
            BigInteger r = ModExp(g, k, p);

            // Calculate e = H(m || r) mod q
            byte[] messageBytes = Encoding.UTF8.GetBytes(txtSignMessageM.Text);
            BigInteger eSign = ComputeHash(messageBytes, r, q);
            txtSignE.Text = eSign.ToString();

            // Calculate s = (k + a*e) mod q
            BigInteger s = (k + a * eSign) % q;
            if (s < 0) s += q;  // Ensure positive
            txtSignS.Text = s.ToString();

            return (s, eSign);
        }

        // Xác thực chữ ký
        private bool VerifySignature()
        {
            if (string.IsNullOrEmpty(txtVerifyPublicKeyY.Text) || 
                string.IsNullOrEmpty(txtVerifyMessageM.Text) || 
                string.IsNullOrEmpty(txtVerifyS.Text) || 
                string.IsNullOrEmpty(txtVerifyE.Text))
                return false;

            BigInteger y = BigInteger.Parse(txtVerifyPublicKeyY.Text);
            BigInteger s = BigInteger.Parse(txtVerifyS.Text);
            BigInteger eSign = BigInteger.Parse(txtVerifyE.Text);

            // Calculate v = g^s * y^(-eSign) mod p
            BigInteger v = (ModExp(g, s, p) * ModExp(y, q - eSign, p)) % p;

            // Calculate eHash = H(m || v) mod q
            byte[] messageBytes = Encoding.UTF8.GetBytes(txtVerifyMessageM.Text);
            BigInteger eHash = ComputeHash(messageBytes, v, q);

            return eHash == eSign;
        }

        #endregion

        #region File Operations

        private string ReadPdfContent(string filePath)
        {
            StringBuilder text = new StringBuilder();
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return text.ToString();
        }

        private string ReadWordContent(string filePath)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Document doc = null;
            string content = "";

            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                doc = wordApp.Documents.Open(filePath);
                content = doc.Content.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file Word: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                    Marshal.ReleaseComObject(doc);
                }
                if (wordApp != null)
                {
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return content;
        }

        private void WriteWordContent(string filePath, string content)
        {
            Microsoft.Office.Interop.Word.Application wordApp = null;
            Document doc = null;

            try
            {
                wordApp = new Microsoft.Office.Interop.Word.Application();
                doc = wordApp.Documents.Add();
                doc.Content.Text = content;
                doc.SaveAs2(filePath);
                MessageBox.Show("Xuất file Word thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi ghi file Word: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                    Marshal.ReleaseComObject(doc);
                }
                if (wordApp != null)
                {
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void btnImportVerifyMsg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtVerifyMsgPath.Text = openFileDialog.FileName;
                    string content = "";
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                content = ReadPdfContent(openFileDialog.FileName);
                                break;
                            case ".doc":
                            case ".docx":
                                content = ReadWordContent(openFileDialog.FileName);
                                break;
                            case ".txt":
                            default:
                                content = File.ReadAllText(openFileDialog.FileName);
                                break;
                        }
                        txtVerifyMessageM.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportSignature_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSignS.Text) || string.IsNullOrEmpty(txtSignE.Text))
            {
                MessageBox.Show("Vui lòng tạo chữ ký trước khi xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string signatureContent = $"{txtSignS.Text}, {txtSignE.Text}";
                    txtExportedSignaturePath.Text = saveFileDialog.FileName;
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();
                    
                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                MessageBox.Show("Chức năng xuất PDF đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case ".doc":
                            case ".docx":
                                WriteWordContent(saveFileDialog.FileName, signatureContent);
                                break;
                            case ".txt":
                            default:
                                File.WriteAllText(saveFileDialog.FileName, signatureContent);
                                MessageBox.Show("Xuất chữ ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportPublicKey_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreatePublicKeyY.Text))
            {
                MessageBox.Show("Vui lòng tạo khóa công khai trước khi xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string publicKeyContent = txtCreatePublicKeyY.Text;
                    txtExportedKeyPath.Text = saveFileDialog.FileName;
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                MessageBox.Show("Chức năng xuất PDF đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case ".doc":
                            case ".docx":
                                WriteWordContent(saveFileDialog.FileName, publicKeyContent);
                                break;
                            case ".txt":
                            default:
                                File.WriteAllText(saveFileDialog.FileName, publicKeyContent);
                                MessageBox.Show("Xuất khóa công khai thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportPublicKeyY_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImportedPublicKeyPath.Text = openFileDialog.FileName;
                    string content = "";
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                content = ReadPdfContent(openFileDialog.FileName);
                                break;
                            case ".doc":
                            case ".docx":
                                content = ReadWordContent(openFileDialog.FileName);
                                break;
                            case ".txt":
                            default:
                                content = File.ReadAllText(openFileDialog.FileName);
                                break;
                        }

                        content = content.Trim();
                        if (!string.IsNullOrEmpty(content))
                        {
                            txtVerifyPublicKeyY.Text = content;
                            MessageBox.Show("Đã nhập khóa công khai thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("File không chứa giá trị khóa công khai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportSignature_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImportedSignaturePath.Text = openFileDialog.FileName;
                    string content = "";
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                content = ReadPdfContent(openFileDialog.FileName);
                                break;
                            case ".doc":
                            case ".docx":
                                content = ReadWordContent(openFileDialog.FileName);
                                break;
                            case ".txt":
                            default:
                                content = File.ReadAllText(openFileDialog.FileName);
                                break;
                        }

                        content = content.Trim();
                        string[] values = content.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        if (values.Length == 2)
                        {
                            txtVerifyS.Text = values[0].Trim();
                            txtVerifyE.Text = values[1].Trim();
                            MessageBox.Show("Đã nhập chữ ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Định dạng file chữ ký không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnImportSignMsg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tệp PDF (*.pdf)|*.pdf|Tệp Word (*.doc;*.docx)|*.doc;*.docx|Tất cả các tệp (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImportedSignMsgPath.Text = openFileDialog.FileName;
                    string content = "";
                    string extension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();

                    try
                    {
                        switch (extension)
                        {
                            case ".pdf":
                                content = ReadPdfContent(openFileDialog.FileName);
                                break;
                            case ".doc":
                            case ".docx":
                                content = ReadWordContent(openFileDialog.FileName);
                                break;
                            case ".txt":
                            default:
                                content = File.ReadAllText(openFileDialog.FileName);
                                break;
                        }
                        txtSignMessageM.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Button Click Events

        private void btnGenPara_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateLargePrimes();
                GenerateG();
                a = RandomNumInZq(q);
                txtPrivateA.Text = a.ToString();
                MessageBox.Show("Tạo tham số thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo tham số: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreatePublicKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtPrimeP.Text) || string.IsNullOrEmpty(txtPrimeQ.Text) || 
                    string.IsNullOrEmpty(txtG.Text) || string.IsNullOrEmpty(txtPrivateA.Text))
                {
                    MessageBox.Show("Vui lòng tạo tham số trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate parameters
                p = BigInteger.Parse(txtPrimeP.Text);
                q = BigInteger.Parse(txtPrimeQ.Text);
                g = BigInteger.Parse(txtG.Text);
                a = BigInteger.Parse(txtPrivateA.Text);

                if (!MillerRabinTest(p))
                {
                    MessageBox.Show("p phải là số nguyên tố!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!MillerRabinTest(q))
                {
                    MessageBox.Show("q phải là số nguyên tố!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if ((p - 1) % q != 0)
                {
                    MessageBox.Show("q phải là ước của p-1!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (g <= 1 || ModExp(g, q, p) != 1)
                {
                    MessageBox.Show("Phần tử sinh g không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (a <= 0 || a >= q)
                {
                    MessageBox.Show("Khóa bí mật a phải thuộc Zq!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                GeneratePublicKey();
                MessageBox.Show("Tạo khóa công khai thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo khóa công khai: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateSignature_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSignMessageM.Text))
                {
                    MessageBox.Show("Vui lòng nhập hoặc nhập thông điệp cần ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var (s, eSign) = GenerateSignature();
                if (s == 0 && eSign == 0)
                {
                    MessageBox.Show("Lỗi khi tạo chữ ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Tạo chữ ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo chữ ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerifySignature_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtVerifyPublicKeyY.Text) || 
                    string.IsNullOrEmpty(txtVerifyMessageM.Text) || 
                    string.IsNullOrEmpty(txtVerifyS.Text) || 
                    string.IsNullOrEmpty(txtVerifyE.Text))
                {
                    MessageBox.Show("Vui lòng cung cấp đầy đủ: khóa công khai, thông điệp và chữ ký!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool result = VerifySignature();
                txtVerifyResult.Text = result ? "Chữ ký hợp lệ" : "Chữ ký không hợp lệ";

                if (!result)
                {
                    // Check for specific verification failures
                    if (txtVerifyMessageM.Text != txtSignMessageM.Text)
                    {
                        txtVerifyResult.Text += " | Lỗi: Thông điệp đã bị thay đổi";
                    }
                    if (txtVerifyS.Text != txtSignS.Text || txtVerifyE.Text != txtSignE.Text)
                    {
                        txtVerifyResult.Text += " | Lỗi: Chữ ký đã bị thay đổi";
                    }
                    txtVerifyResult.Text += " | Kiểm tra lại khoá công khai";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xác thực chữ ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}