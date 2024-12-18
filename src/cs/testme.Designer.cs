using System;
using System.Drawing;
using System.Windows.Forms;

namespace schnorr_signature_scheme_csharp
{
    public partial class testme : Form
    {
        // Panels
        private Panel panelCreateKey;
        private Panel panelCreateSignature;
        private Panel panelVerifySignature;

        // Controls for Create Key Panel
        private Label lblTitleCreateKey;
        private Label lblSelectPrimeP;
        private TextBox txtPrimeP;
        private Button btnGenerateP;
        private Label lblSelectPrimeQ;
        private TextBox txtPrimeQ;
        private Button btnGenerateQ;
        private Label lblSelectB;
        private TextBox txtB;
        private Button btnGenerateB;
        private Label lblSelectA;
        private TextBox txtA;
        private Button btnGenerateA;
        private Button btnCreateKey;
        private Label lblGValue;
        private TextBox txtGValue;
        private Label lblYValue;
        private TextBox txtYValue;
        private Label lblPublicKey;
        private TextBox txtPublicKey;

        // Controls for Create Signature Panel
        private Label lblTitleCreateSignature;
        private Label lblMessage;
        private TextBox txtMessagePath;
        private Button btnUploadMessage;
        private TextBox txtMessageText;
        private Label lblSelectK;
        private TextBox txtK;
        private Button btnGenerateK;
        private Button btnCreateSignature;
        private Label lblSValue;
        private TextBox txtSValue;
        private Label lblEValue;
        private TextBox txtEValue;
        private Label lblSignature;
        private TextBox txtSignature;

        // Controls for Verify Signature Panel
        private Label lblTitleVerifySignature;
        private Label lblMessageVerify;
        private TextBox txtMessageVerifyPath;
        private Button btnUploadMessageVerify;
        private TextBox txtMessageVerifyText;
        private Label lblSignatureInput;
        private TextBox txtSignatureInput;
        private Label lblPublicKeyInput;
        private TextBox txtPublicKeyInput;
        private Button btnVerifySignature;
        private Label lblVerifyResult;
        private TextBox txtVerifyResult;

        // OpenFileDialogs
        private OpenFileDialog openFileDialog;
        private System.ComponentModel.IContainer components;
        
        private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.txtPrimeP = new System.Windows.Forms.TextBox();
                this.txtPrimeQ = new System.Windows.Forms.TextBox();
                this.txtB = new System.Windows.Forms.TextBox();
                this.txtA = new System.Windows.Forms.TextBox();
                this.txtK = new System.Windows.Forms.TextBox();
                this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
                this.panelCreateKey = new System.Windows.Forms.Panel();
                this.lblTitleCreateKey = new System.Windows.Forms.Label();
                this.lblSelectPrimeP = new System.Windows.Forms.Label();
                this.btnGenerateP = new System.Windows.Forms.Button();
                this.lblSelectPrimeQ = new System.Windows.Forms.Label();
                this.btnGenerateQ = new System.Windows.Forms.Button();
                this.lblSelectB = new System.Windows.Forms.Label();
                this.btnGenerateB = new System.Windows.Forms.Button();
                this.lblSelectA = new System.Windows.Forms.Label();
                this.btnGenerateA = new System.Windows.Forms.Button();
                this.btnCreateKey = new System.Windows.Forms.Button();
                this.lblGValue = new System.Windows.Forms.Label();
                this.txtGValue = new System.Windows.Forms.TextBox();
                this.lblYValue = new System.Windows.Forms.Label();
                this.txtYValue = new System.Windows.Forms.TextBox();
                this.lblPublicKey = new System.Windows.Forms.Label();
                this.txtPublicKey = new System.Windows.Forms.TextBox();
                this.panelCreateSignature = new System.Windows.Forms.Panel();
                this.lblTitleCreateSignature = new System.Windows.Forms.Label();
                this.lblMessage = new System.Windows.Forms.Label();
                this.txtMessagePath = new System.Windows.Forms.TextBox();
                this.btnUploadMessage = new System.Windows.Forms.Button();
                this.txtMessageText = new System.Windows.Forms.TextBox();
                this.lblSelectK = new System.Windows.Forms.Label();
                this.btnGenerateK = new System.Windows.Forms.Button();
                this.btnCreateSignature = new System.Windows.Forms.Button();
                this.lblSValue = new System.Windows.Forms.Label();
                this.txtSValue = new System.Windows.Forms.TextBox();
                this.lblEValue = new System.Windows.Forms.Label();
                this.txtEValue = new System.Windows.Forms.TextBox();
                this.lblSignature = new System.Windows.Forms.Label();
                this.txtSignature = new System.Windows.Forms.TextBox();
                this.panelVerifySignature = new System.Windows.Forms.Panel();
                this.lblTitleVerifySignature = new System.Windows.Forms.Label();
                this.lblMessageVerify = new System.Windows.Forms.Label();
                this.txtMessageVerifyPath = new System.Windows.Forms.TextBox();
                this.btnUploadMessageVerify = new System.Windows.Forms.Button();
                this.txtMessageVerifyText = new System.Windows.Forms.TextBox();
                this.lblSignatureInput = new System.Windows.Forms.Label();
                this.txtSignatureInput = new System.Windows.Forms.TextBox();
                this.lblPublicKeyInput = new System.Windows.Forms.Label();
                this.txtPublicKeyInput = new System.Windows.Forms.TextBox();
                this.btnVerifySignature = new System.Windows.Forms.Button();
                this.lblVerifyResult = new System.Windows.Forms.Label();
                this.txtVerifyResult = new System.Windows.Forms.TextBox();
                this.panelCreateKey.SuspendLayout();
                this.panelCreateSignature.SuspendLayout();
                this.panelVerifySignature.SuspendLayout();
                this.SuspendLayout();
                // 
                // txtPrimeP
                // 
                this.txtPrimeP.Location = new System.Drawing.Point(10, 75);
                this.txtPrimeP.Name = "txtPrimeP";
                this.txtPrimeP.Size = new System.Drawing.Size(260, 22);
                this.txtPrimeP.TabIndex = 2;
                // 
                // txtPrimeQ
                // 
                this.txtPrimeQ.Location = new System.Drawing.Point(10, 135);
                this.txtPrimeQ.Name = "txtPrimeQ";
                this.txtPrimeQ.Size = new System.Drawing.Size(260, 22);
                this.txtPrimeQ.TabIndex = 5;
                // 
                // txtB
                // 
                this.txtB.Location = new System.Drawing.Point(10, 195);
                this.txtB.Name = "txtB";
                this.txtB.Size = new System.Drawing.Size(260, 22);
                this.txtB.TabIndex = 8;
                // 
                // txtA
                // 
                this.txtA.Location = new System.Drawing.Point(10, 255);
                this.txtA.Name = "txtA";
                this.txtA.Size = new System.Drawing.Size(260, 22);
                this.txtA.TabIndex = 11;
                // 
                // txtK
                // 
                this.txtK.Location = new System.Drawing.Point(10, 205);
                this.txtK.Name = "txtK";
                this.txtK.Size = new System.Drawing.Size(262, 22);
                this.txtK.TabIndex = 6;
                // 
                // panelCreateKey
                // 
                this.panelCreateKey.BackColor = System.Drawing.SystemColors.Control;
                this.panelCreateKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.panelCreateKey.Controls.Add(this.lblTitleCreateKey);
                this.panelCreateKey.Controls.Add(this.lblSelectPrimeP);
                this.panelCreateKey.Controls.Add(this.txtPrimeP);
                this.panelCreateKey.Controls.Add(this.btnGenerateP);
                this.panelCreateKey.Controls.Add(this.lblSelectPrimeQ);
                this.panelCreateKey.Controls.Add(this.txtPrimeQ);
                this.panelCreateKey.Controls.Add(this.btnGenerateQ);
                this.panelCreateKey.Controls.Add(this.lblSelectB);
                this.panelCreateKey.Controls.Add(this.txtB);
                this.panelCreateKey.Controls.Add(this.btnGenerateB);
                this.panelCreateKey.Controls.Add(this.lblSelectA);
                this.panelCreateKey.Controls.Add(this.txtA);
                this.panelCreateKey.Controls.Add(this.btnGenerateA);
                this.panelCreateKey.Controls.Add(this.btnCreateKey);
                this.panelCreateKey.Controls.Add(this.lblGValue);
                this.panelCreateKey.Controls.Add(this.txtGValue);
                this.panelCreateKey.Controls.Add(this.lblYValue);
                this.panelCreateKey.Controls.Add(this.txtYValue);
                this.panelCreateKey.Controls.Add(this.lblPublicKey);
                this.panelCreateKey.Controls.Add(this.txtPublicKey);
                this.panelCreateKey.Location = new System.Drawing.Point(10, 10);
                this.panelCreateKey.Name = "panelCreateKey";
                this.panelCreateKey.Size = new System.Drawing.Size(380, 600);
                this.panelCreateKey.TabIndex = 0;
                // 
                // lblTitleCreateKey
                // 
                this.lblTitleCreateKey.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
                this.lblTitleCreateKey.Location = new System.Drawing.Point(10, 10);
                this.lblTitleCreateKey.Name = "lblTitleCreateKey";
                this.lblTitleCreateKey.Size = new System.Drawing.Size(100, 25);
                this.lblTitleCreateKey.TabIndex = 0;
                this.lblTitleCreateKey.Text = "Tạo Khóa";
                // 
                // lblSelectPrimeP
                // 
                this.lblSelectPrimeP.Location = new System.Drawing.Point(10, 50);
                this.lblSelectPrimeP.Name = "lblSelectPrimeP";
                this.lblSelectPrimeP.Size = new System.Drawing.Size(200, 20);
                this.lblSelectPrimeP.TabIndex = 1;
                this.lblSelectPrimeP.Text = "Chọn số nguyên tố p:";
                // 
                // btnGenerateP
                // 
                this.btnGenerateP.BackColor = System.Drawing.Color.LightBlue;
                this.btnGenerateP.Location = new System.Drawing.Point(295, 73);
                this.btnGenerateP.Name = "btnGenerateP";
                this.btnGenerateP.Size = new System.Drawing.Size(50, 23);
                this.btnGenerateP.TabIndex = 3;
                this.btnGenerateP.Text = "Gen";
                this.btnGenerateP.UseVisualStyleBackColor = false;
                this.btnGenerateP.Click += new System.EventHandler(this.BtnGenerateP_Click);
                // 
                // lblSelectPrimeQ
                // 
                this.lblSelectPrimeQ.Location = new System.Drawing.Point(10, 110);
                this.lblSelectPrimeQ.Name = "lblSelectPrimeQ";
                this.lblSelectPrimeQ.Size = new System.Drawing.Size(250, 20);
                this.lblSelectPrimeQ.TabIndex = 4;
                this.lblSelectPrimeQ.Text = "Chọn số nguyên tố q là ước của (p - 1):";
                // 
                // btnGenerateQ
                // 
                this.btnGenerateQ.BackColor = System.Drawing.Color.LightBlue;
                this.btnGenerateQ.Location = new System.Drawing.Point(295, 133);
                this.btnGenerateQ.Name = "btnGenerateQ";
                this.btnGenerateQ.Size = new System.Drawing.Size(50, 23);
                this.btnGenerateQ.TabIndex = 6;
                this.btnGenerateQ.Text = "Gen";
                this.btnGenerateQ.UseVisualStyleBackColor = false;
                this.btnGenerateQ.Click += new System.EventHandler(this.BtnGenerateQ_Click);
                // 
                // lblSelectB
                // 
                this.lblSelectB.Location = new System.Drawing.Point(10, 170);
                this.lblSelectB.Name = "lblSelectB";
                this.lblSelectB.Size = new System.Drawing.Size(100, 20);
                this.lblSelectB.TabIndex = 7;
                this.lblSelectB.Text = "Chọn b ∈ Z*_p:";
                // 
                // btnGenerateB
                // 
                this.btnGenerateB.BackColor = System.Drawing.Color.LightBlue;
                this.btnGenerateB.Location = new System.Drawing.Point(295, 193);
                this.btnGenerateB.Name = "btnGenerateB";
                this.btnGenerateB.Size = new System.Drawing.Size(50, 23);
                this.btnGenerateB.TabIndex = 9;
                this.btnGenerateB.Text = "Gen";
                this.btnGenerateB.UseVisualStyleBackColor = false;
                this.btnGenerateB.Click += new System.EventHandler(this.BtnGenerateB_Click);
                // 
                // lblSelectA
                // 
                this.lblSelectA.Location = new System.Drawing.Point(10, 230);
                this.lblSelectA.Name = "lblSelectA";
                this.lblSelectA.Size = new System.Drawing.Size(100, 20);
                this.lblSelectA.TabIndex = 10;
                this.lblSelectA.Text = "Chọn a ∈ Z_q:";
                // 
                // btnGenerateA
                // 
                this.btnGenerateA.BackColor = System.Drawing.Color.LightBlue;
                this.btnGenerateA.Location = new System.Drawing.Point(295, 253);
                this.btnGenerateA.Name = "btnGenerateA";
                this.btnGenerateA.Size = new System.Drawing.Size(50, 23);
                this.btnGenerateA.TabIndex = 12;
                this.btnGenerateA.Text = "Gen";
                this.btnGenerateA.UseVisualStyleBackColor = false;
                this.btnGenerateA.Click += new System.EventHandler(this.BtnGenerateA_Click);
                // 
                // btnCreateKey
                // 
                this.btnCreateKey.BackColor = System.Drawing.Color.Green;
                this.btnCreateKey.ForeColor = System.Drawing.Color.White;
                this.btnCreateKey.Location = new System.Drawing.Point(41, 302);
                this.btnCreateKey.Name = "btnCreateKey";
                this.btnCreateKey.Size = new System.Drawing.Size(260, 35);
                this.btnCreateKey.TabIndex = 13;
                this.btnCreateKey.Text = "TẠO";
                this.btnCreateKey.UseVisualStyleBackColor = false;
                this.btnCreateKey.Click += new System.EventHandler(this.BtnCreateKey_Click);
                // 
                // lblGValue
                // 
                this.lblGValue.Location = new System.Drawing.Point(12, 350);
                this.lblGValue.Name = "lblGValue";
                this.lblGValue.Size = new System.Drawing.Size(250, 20);
                this.lblGValue.TabIndex = 14;
                this.lblGValue.Text = "Giá trị g = b^((p-1)/q) mod p và g ≠ 1:";
                // 
                // txtGValue
                // 
                this.txtGValue.Location = new System.Drawing.Point(12, 375);
                this.txtGValue.Name = "txtGValue";
                this.txtGValue.ReadOnly = true;
                this.txtGValue.Size = new System.Drawing.Size(260, 22);
                this.txtGValue.TabIndex = 15;
                // 
                // lblYValue
                // 
                this.lblYValue.Location = new System.Drawing.Point(12, 405);
                this.lblYValue.Name = "lblYValue";
                this.lblYValue.Size = new System.Drawing.Size(150, 20);
                this.lblYValue.TabIndex = 16;
                this.lblYValue.Text = "Giá trị y = g^a mod p:";
                // 
                // txtYValue
                // 
                this.txtYValue.Location = new System.Drawing.Point(12, 430);
                this.txtYValue.Name = "txtYValue";
                this.txtYValue.ReadOnly = true;
                this.txtYValue.Size = new System.Drawing.Size(260, 22);
                this.txtYValue.TabIndex = 17;
                // 
                // lblPublicKey
                // 
                this.lblPublicKey.Location = new System.Drawing.Point(12, 460);
                this.lblPublicKey.Name = "lblPublicKey";
                this.lblPublicKey.Size = new System.Drawing.Size(200, 20);
                this.lblPublicKey.TabIndex = 18;
                this.lblPublicKey.Text = "Khóa công khai: (p, q, g, y):";
                // 
                // txtPublicKey
                // 
                this.txtPublicKey.Location = new System.Drawing.Point(12, 485);
                this.txtPublicKey.Name = "txtPublicKey";
                this.txtPublicKey.ReadOnly = true;
                this.txtPublicKey.Size = new System.Drawing.Size(260, 22);
                this.txtPublicKey.TabIndex = 19;
                // 
                // panelCreateSignature
                // 
                this.panelCreateSignature.BackColor = System.Drawing.SystemColors.Control;
                this.panelCreateSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.panelCreateSignature.Controls.Add(this.lblTitleCreateSignature);
                this.panelCreateSignature.Controls.Add(this.lblMessage);
                this.panelCreateSignature.Controls.Add(this.txtMessagePath);
                this.panelCreateSignature.Controls.Add(this.btnUploadMessage);
                this.panelCreateSignature.Controls.Add(this.txtMessageText);
                this.panelCreateSignature.Controls.Add(this.lblSelectK);
                this.panelCreateSignature.Controls.Add(this.txtK);
                this.panelCreateSignature.Controls.Add(this.btnGenerateK);
                this.panelCreateSignature.Controls.Add(this.btnCreateSignature);
                this.panelCreateSignature.Controls.Add(this.lblSValue);
                this.panelCreateSignature.Controls.Add(this.txtSValue);
                this.panelCreateSignature.Controls.Add(this.lblEValue);
                this.panelCreateSignature.Controls.Add(this.txtEValue);
                this.panelCreateSignature.Controls.Add(this.lblSignature);
                this.panelCreateSignature.Controls.Add(this.txtSignature);
                this.panelCreateSignature.Location = new System.Drawing.Point(400, 10);
                this.panelCreateSignature.Name = "panelCreateSignature";
                this.panelCreateSignature.Size = new System.Drawing.Size(380, 600);
                this.panelCreateSignature.TabIndex = 1;
                // 
                // lblTitleCreateSignature
                // 
                this.lblTitleCreateSignature.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
                this.lblTitleCreateSignature.Location = new System.Drawing.Point(10, 10);
                this.lblTitleCreateSignature.Name = "lblTitleCreateSignature";
                this.lblTitleCreateSignature.Size = new System.Drawing.Size(130, 25);
                this.lblTitleCreateSignature.TabIndex = 0;
                this.lblTitleCreateSignature.Text = "Tạo Chữ Ký";
                // 
                // lblMessage
                // 
                this.lblMessage.Location = new System.Drawing.Point(10, 50);
                this.lblMessage.Name = "lblMessage";
                this.lblMessage.Size = new System.Drawing.Size(100, 20);
                this.lblMessage.TabIndex = 1;
                this.lblMessage.Text = "Thông điệp m:";
                // 
                // txtMessagePath
                // 
                this.txtMessagePath.Location = new System.Drawing.Point(10, 75);
                this.txtMessagePath.Name = "txtMessagePath";
                this.txtMessagePath.Size = new System.Drawing.Size(262, 22);
                this.txtMessagePath.TabIndex = 2;
                // 
                // btnUploadMessage
                // 
                this.btnUploadMessage.BackColor = System.Drawing.Color.LightBlue;
                this.btnUploadMessage.Location = new System.Drawing.Point(283, 73);
                this.btnUploadMessage.Name = "btnUploadMessage";
                this.btnUploadMessage.Size = new System.Drawing.Size(70, 23);
                this.btnUploadMessage.TabIndex = 3;
                this.btnUploadMessage.Text = "Upload";
                this.btnUploadMessage.UseVisualStyleBackColor = false;
                this.btnUploadMessage.Click += new System.EventHandler(this.BtnUploadMessage_Click);
                // 
                // txtMessageText
                // 
                this.txtMessageText.Location = new System.Drawing.Point(10, 105);
                this.txtMessageText.Multiline = true;
                this.txtMessageText.Name = "txtMessageText";
                this.txtMessageText.Size = new System.Drawing.Size(343, 60);
                this.txtMessageText.TabIndex = 4;
                // 
                // lblSelectK
                // 
                this.lblSelectK.Location = new System.Drawing.Point(10, 180);
                this.lblSelectK.Name = "lblSelectK";
                this.lblSelectK.Size = new System.Drawing.Size(100, 20);
                this.lblSelectK.TabIndex = 5;
                this.lblSelectK.Text = "Chọn k ∈ Z_q:";
                // 
                // btnGenerateK
                // 
                this.btnGenerateK.BackColor = System.Drawing.Color.LightBlue;
                this.btnGenerateK.Location = new System.Drawing.Point(303, 205);
                this.btnGenerateK.Name = "btnGenerateK";
                this.btnGenerateK.Size = new System.Drawing.Size(50, 23);
                this.btnGenerateK.TabIndex = 7;
                this.btnGenerateK.Text = "Gen";
                this.btnGenerateK.UseVisualStyleBackColor = false;
                this.btnGenerateK.Click += new System.EventHandler(this.BtnGenerateK_Click);
                // 
                // btnCreateSignature
                // 
                this.btnCreateSignature.BackColor = System.Drawing.Color.Green;
                this.btnCreateSignature.ForeColor = System.Drawing.Color.White;
                this.btnCreateSignature.Location = new System.Drawing.Point(50, 302);
                this.btnCreateSignature.Name = "btnCreateSignature";
                this.btnCreateSignature.Size = new System.Drawing.Size(260, 35);
                this.btnCreateSignature.TabIndex = 8;
                this.btnCreateSignature.Text = "TẠO";
                this.btnCreateSignature.UseVisualStyleBackColor = false;
                this.btnCreateSignature.Click += new System.EventHandler(this.BtnCreateSignature_Click);
                // 
                // lblSValue
                // 
                this.lblSValue.Location = new System.Drawing.Point(12, 350);
                this.lblSValue.Name = "lblSValue";
                this.lblSValue.Size = new System.Drawing.Size(200, 20);
                this.lblSValue.TabIndex = 9;
                this.lblSValue.Text = "Giá trị s = (a * e + k) mod q:";
                // 
                // txtSValue
                // 
                this.txtSValue.Location = new System.Drawing.Point(12, 375);
                this.txtSValue.Name = "txtSValue";
                this.txtSValue.ReadOnly = true;
                this.txtSValue.Size = new System.Drawing.Size(260, 22);
                this.txtSValue.TabIndex = 10;
                // 
                // lblEValue
                // 
                this.lblEValue.Location = new System.Drawing.Point(12, 405);
                this.lblEValue.Name = "lblEValue";
                this.lblEValue.Size = new System.Drawing.Size(200, 20);
                this.lblEValue.TabIndex = 11;
                this.lblEValue.Text = "Giá trị e = h(m || g^k mod p):";
                // 
                // txtEValue
                // 
                this.txtEValue.Location = new System.Drawing.Point(12, 430);
                this.txtEValue.Name = "txtEValue";
                this.txtEValue.ReadOnly = true;
                this.txtEValue.Size = new System.Drawing.Size(260, 22);
                this.txtEValue.TabIndex = 12;
                // 
                // lblSignature
                // 
                this.lblSignature.Location = new System.Drawing.Point(12, 460);
                this.lblSignature.Name = "lblSignature";
                this.lblSignature.Size = new System.Drawing.Size(100, 20);
                this.lblSignature.TabIndex = 13;
                this.lblSignature.Text = "Chữ ký (s, e):";
                // 
                // txtSignature
                // 
                this.txtSignature.Location = new System.Drawing.Point(12, 485);
                this.txtSignature.Name = "txtSignature";
                this.txtSignature.ReadOnly = true;
                this.txtSignature.Size = new System.Drawing.Size(260, 22);
                this.txtSignature.TabIndex = 14;
                // 
                // panelVerifySignature
                // 
                this.panelVerifySignature.BackColor = System.Drawing.SystemColors.Control;
                this.panelVerifySignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.panelVerifySignature.Controls.Add(this.lblTitleVerifySignature);
                this.panelVerifySignature.Controls.Add(this.lblMessageVerify);
                this.panelVerifySignature.Controls.Add(this.txtMessageVerifyPath);
                this.panelVerifySignature.Controls.Add(this.btnUploadMessageVerify);
                this.panelVerifySignature.Controls.Add(this.txtMessageVerifyText);
                this.panelVerifySignature.Controls.Add(this.lblSignatureInput);
                this.panelVerifySignature.Controls.Add(this.txtSignatureInput);
                this.panelVerifySignature.Controls.Add(this.lblPublicKeyInput);
                this.panelVerifySignature.Controls.Add(this.txtPublicKeyInput);
                this.panelVerifySignature.Controls.Add(this.btnVerifySignature);
                this.panelVerifySignature.Controls.Add(this.lblVerifyResult);
                this.panelVerifySignature.Controls.Add(this.txtVerifyResult);
                this.panelVerifySignature.Location = new System.Drawing.Point(790, 10);
                this.panelVerifySignature.Name = "panelVerifySignature";
                this.panelVerifySignature.Size = new System.Drawing.Size(380, 600);
                this.panelVerifySignature.TabIndex = 2;
                // 
                // lblTitleVerifySignature
                // 
                this.lblTitleVerifySignature.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
                this.lblTitleVerifySignature.Location = new System.Drawing.Point(10, 10);
                this.lblTitleVerifySignature.Name = "lblTitleVerifySignature";
                this.lblTitleVerifySignature.Size = new System.Drawing.Size(160, 25);
                this.lblTitleVerifySignature.TabIndex = 0;
                this.lblTitleVerifySignature.Text = "Xác Minh Chữ Ký";
                // 
                // lblMessageVerify
                // 
                this.lblMessageVerify.Location = new System.Drawing.Point(10, 50);
                this.lblMessageVerify.Name = "lblMessageVerify";
                this.lblMessageVerify.Size = new System.Drawing.Size(100, 20);
                this.lblMessageVerify.TabIndex = 1;
                this.lblMessageVerify.Text = "Thông điệp m:";
                // 
                // txtMessageVerifyPath
                // 
                this.txtMessageVerifyPath.Location = new System.Drawing.Point(10, 75);
                this.txtMessageVerifyPath.Name = "txtMessageVerifyPath";
                this.txtMessageVerifyPath.Size = new System.Drawing.Size(260, 22);
                this.txtMessageVerifyPath.TabIndex = 2;
                // 
                // btnUploadMessageVerify
                // 
                this.btnUploadMessageVerify.BackColor = System.Drawing.Color.LightBlue;
                this.btnUploadMessageVerify.Location = new System.Drawing.Point(286, 73);
                this.btnUploadMessageVerify.Name = "btnUploadMessageVerify";
                this.btnUploadMessageVerify.Size = new System.Drawing.Size(70, 23);
                this.btnUploadMessageVerify.TabIndex = 3;
                this.btnUploadMessageVerify.Text = "Upload";
                this.btnUploadMessageVerify.UseVisualStyleBackColor = false;
                this.btnUploadMessageVerify.Click += new System.EventHandler(this.BtnUploadMessageVerify_Click);
                // 
                // txtMessageVerifyText
                // 
                this.txtMessageVerifyText.Location = new System.Drawing.Point(10, 105);
                this.txtMessageVerifyText.Multiline = true;
                this.txtMessageVerifyText.Name = "txtMessageVerifyText";
                this.txtMessageVerifyText.Size = new System.Drawing.Size(346, 60);
                this.txtMessageVerifyText.TabIndex = 4;
                // 
                // lblSignatureInput
                // 
                this.lblSignatureInput.Location = new System.Drawing.Point(10, 180);
                this.lblSignatureInput.Name = "lblSignatureInput";
                this.lblSignatureInput.Size = new System.Drawing.Size(128, 22);
                this.lblSignatureInput.TabIndex = 5;
                this.lblSignatureInput.Text = "Nhập chữ ký (s, e):";
                // 
                // txtSignatureInput
                // 
                this.txtSignatureInput.Location = new System.Drawing.Point(10, 205);
                this.txtSignatureInput.Name = "txtSignatureInput";
                this.txtSignatureInput.Size = new System.Drawing.Size(260, 22);
                this.txtSignatureInput.TabIndex = 6;
                // 
                // lblPublicKeyInput
                // 
                this.lblPublicKeyInput.Location = new System.Drawing.Point(10, 240);
                this.lblPublicKeyInput.Name = "lblPublicKeyInput";
                this.lblPublicKeyInput.Size = new System.Drawing.Size(207, 20);
                this.lblPublicKeyInput.TabIndex = 7;
                this.lblPublicKeyInput.Text = "Nhập khóa công khai (p, q, g, y):";
                // 
                // txtPublicKeyInput
                // 
                this.txtPublicKeyInput.Location = new System.Drawing.Point(10, 265);
                this.txtPublicKeyInput.Name = "txtPublicKeyInput";
                this.txtPublicKeyInput.Size = new System.Drawing.Size(260, 22);
                this.txtPublicKeyInput.TabIndex = 8;
                // 
                // btnVerifySignature
                // 
                this.btnVerifySignature.BackColor = System.Drawing.Color.Green;
                this.btnVerifySignature.ForeColor = System.Drawing.Color.White;
                this.btnVerifySignature.Location = new System.Drawing.Point(79, 302);
                this.btnVerifySignature.Name = "btnVerifySignature";
                this.btnVerifySignature.Size = new System.Drawing.Size(260, 35);
                this.btnVerifySignature.TabIndex = 9;
                this.btnVerifySignature.Text = "XÁC MINH";
                this.btnVerifySignature.UseVisualStyleBackColor = false;
                this.btnVerifySignature.Click += new System.EventHandler(this.BtnVerifySignature_Click);
                // 
                // lblVerifyResult
                // 
                this.lblVerifyResult.Location = new System.Drawing.Point(10, 350);
                this.lblVerifyResult.Name = "lblVerifyResult";
                this.lblVerifyResult.Size = new System.Drawing.Size(150, 20);
                this.lblVerifyResult.TabIndex = 10;
                this.lblVerifyResult.Text = "Kết quả xác minh:";
                // 
                // txtVerifyResult
                // 
                this.txtVerifyResult.Location = new System.Drawing.Point(10, 375);
                this.txtVerifyResult.Name = "txtVerifyResult";
                this.txtVerifyResult.ReadOnly = true;
                this.txtVerifyResult.Size = new System.Drawing.Size(260, 22);
                this.txtVerifyResult.TabIndex = 11;
                // 
                // testme
                // 
                this.BackColor = System.Drawing.SystemColors.ControlDark;
                this.ClientSize = new System.Drawing.Size(1180, 630);
                this.Controls.Add(this.panelCreateKey);
                this.Controls.Add(this.panelCreateSignature);
                this.Controls.Add(this.panelVerifySignature);
                this.Name = "testme";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Schnorr Signature Scheme Demo";
                this.panelCreateKey.ResumeLayout(false);
                this.panelCreateKey.PerformLayout();
                this.panelCreateSignature.ResumeLayout(false);
                this.panelCreateSignature.PerformLayout();
                this.panelVerifySignature.ResumeLayout(false);
                this.panelVerifySignature.PerformLayout();
                this.ResumeLayout(false);
            }
    }
}