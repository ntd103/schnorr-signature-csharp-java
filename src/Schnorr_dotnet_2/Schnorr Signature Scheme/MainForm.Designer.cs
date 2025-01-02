namespace Schnorr_Signature_Scheme
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlKeyGen = new System.Windows.Forms.Panel();
            this.btnCreatePublicKey = new System.Windows.Forms.Button();
            this.txtExportedKeyPath = new System.Windows.Forms.TextBox();
            this.btnExportPublicKey = new System.Windows.Forms.Button();
            this.btnGenPara = new System.Windows.Forms.Button();
            this.txtCreatePublicKeyY = new System.Windows.Forms.TextBox();
            this.txtPrivateA = new System.Windows.Forms.TextBox();
            this.txtG = new System.Windows.Forms.TextBox();
            this.txtPrimeQ = new System.Windows.Forms.TextBox();
            this.txtPrimeP = new System.Windows.Forms.TextBox();
            this.lblPublicKeyY = new System.Windows.Forms.Label();
            this.lblPrivateKeyA = new System.Windows.Forms.Label();
            this.lblG = new System.Windows.Forms.Label();
            this.lblPrimeQ = new System.Windows.Forms.Label();
            this.lblPrimeP = new System.Windows.Forms.Label();
            this.lblKeyGenTitle = new System.Windows.Forms.Label();
            this.pnlVerify = new System.Windows.Forms.Panel();
            this.lblEnterSignature = new System.Windows.Forms.Label();
            this.txtVerifyResult = new System.Windows.Forms.TextBox();
            this.txtImportedPublicKeyPath = new System.Windows.Forms.TextBox();
            this.txtImportedSignaturePath = new System.Windows.Forms.TextBox();
            this.txtVerifyPublicKeyY = new System.Windows.Forms.TextBox();
            this.txtVerifyE = new System.Windows.Forms.TextBox();
            this.txtVerifyS = new System.Windows.Forms.TextBox();
            this.txtVerifyMessageM = new System.Windows.Forms.TextBox();
            this.txtVerifyMsgPath = new System.Windows.Forms.TextBox();
            this.btnImportPublicKeyY = new System.Windows.Forms.Button();
            this.btnImportSignature = new System.Windows.Forms.Button();
            this.btnVerifySignature = new System.Windows.Forms.Button();
            this.btnImportVerifyMsg = new System.Windows.Forms.Button();
            this.lblVerifyResult = new System.Windows.Forms.Label();
            this.lblVerifyPublicKeyY = new System.Windows.Forms.Label();
            this.lblVerifyE = new System.Windows.Forms.Label();
            this.lblVerifyS = new System.Windows.Forms.Label();
            this.lblVerifyMessageM = new System.Windows.Forms.Label();
            this.lblVerifyTitle = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.pnlSign = new System.Windows.Forms.Panel();
            this.txtSignE = new System.Windows.Forms.TextBox();
            this.txtSignS = new System.Windows.Forms.TextBox();
            this.txtK = new System.Windows.Forms.TextBox();
            this.txtSignMessageM = new System.Windows.Forms.TextBox();
            this.txtImportedSignMsgPath = new System.Windows.Forms.TextBox();
            this.txtExportedSignaturePath = new System.Windows.Forms.TextBox();
            this.btnImportSignMsg = new System.Windows.Forms.Button();
            this.btnCreateSignature = new System.Windows.Forms.Button();
            this.btnExportSignature = new System.Windows.Forms.Button();
            this.lblSignE = new System.Windows.Forms.Label();
            this.lblSignS = new System.Windows.Forms.Label();
            this.lblK = new System.Windows.Forms.Label();
            this.lblSignMessageM = new System.Windows.Forms.Label();
            this.lblSignTitle = new System.Windows.Forms.Label();
            this.pnlKeyGen.SuspendLayout();
            this.pnlVerify.SuspendLayout();
            this.pnlSign.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKeyGen
            // 
            this.pnlKeyGen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlKeyGen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKeyGen.Controls.Add(this.btnCreatePublicKey);
            this.pnlKeyGen.Controls.Add(this.txtExportedKeyPath);
            this.pnlKeyGen.Controls.Add(this.btnExportPublicKey);
            this.pnlKeyGen.Controls.Add(this.btnGenPara);
            this.pnlKeyGen.Controls.Add(this.txtCreatePublicKeyY);
            this.pnlKeyGen.Controls.Add(this.txtPrivateA);
            this.pnlKeyGen.Controls.Add(this.txtG);
            this.pnlKeyGen.Controls.Add(this.txtPrimeQ);
            this.pnlKeyGen.Controls.Add(this.txtPrimeP);
            this.pnlKeyGen.Controls.Add(this.lblPublicKeyY);
            this.pnlKeyGen.Controls.Add(this.lblPrivateKeyA);
            this.pnlKeyGen.Controls.Add(this.lblG);
            this.pnlKeyGen.Controls.Add(this.lblPrimeQ);
            this.pnlKeyGen.Controls.Add(this.lblPrimeP);
            this.pnlKeyGen.Controls.Add(this.lblKeyGenTitle);
            this.pnlKeyGen.Location = new System.Drawing.Point(12, 20);
            this.pnlKeyGen.Name = "pnlKeyGen";
            this.pnlKeyGen.Padding = new System.Windows.Forms.Padding(15);
            this.pnlKeyGen.Size = new System.Drawing.Size(435, 693);
            this.pnlKeyGen.TabIndex = 0;
            // 
            // btnCreatePublicKey
            // 
            this.btnCreatePublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCreatePublicKey.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCreatePublicKey.FlatAppearance.BorderSize = 3;
            this.btnCreatePublicKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePublicKey.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreatePublicKey.ForeColor = System.Drawing.Color.White;
            this.btnCreatePublicKey.Location = new System.Drawing.Point(18, 445);
            this.btnCreatePublicKey.Name = "btnCreatePublicKey";
            this.btnCreatePublicKey.Size = new System.Drawing.Size(379, 46);
            this.btnCreatePublicKey.TabIndex = 14;
            this.btnCreatePublicKey.Text = "Tạo Khoá";
            this.btnCreatePublicKey.UseVisualStyleBackColor = false;
            this.btnCreatePublicKey.Click += new System.EventHandler(this.btnCreatePublicKey_Click);
            // 
            // txtExportedKeyPath
            // 
            this.txtExportedKeyPath.BackColor = System.Drawing.Color.White;
            this.txtExportedKeyPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtExportedKeyPath.Location = new System.Drawing.Point(18, 605);
            this.txtExportedKeyPath.Name = "txtExportedKeyPath";
            this.txtExportedKeyPath.ReadOnly = true;
            this.txtExportedKeyPath.Size = new System.Drawing.Size(262, 30);
            this.txtExportedKeyPath.TabIndex = 0;
            // 
            // btnExportPublicKey
            // 
            this.btnExportPublicKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExportPublicKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPublicKey.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportPublicKey.ForeColor = System.Drawing.Color.White;
            this.btnExportPublicKey.Location = new System.Drawing.Point(287, 605);
            this.btnExportPublicKey.Name = "btnExportPublicKey";
            this.btnExportPublicKey.Size = new System.Drawing.Size(98, 30);
            this.btnExportPublicKey.TabIndex = 1;
            this.btnExportPublicKey.Text = "Xuất khoá";
            this.btnExportPublicKey.UseVisualStyleBackColor = false;
            this.btnExportPublicKey.Click += new System.EventHandler(this.btnExportPublicKey_Click);
            // 
            // btnGenPara
            // 
            this.btnGenPara.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnGenPara.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenPara.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnGenPara.ForeColor = System.Drawing.Color.White;
            this.btnGenPara.Location = new System.Drawing.Point(18, 93);
            this.btnGenPara.Name = "btnGenPara";
            this.btnGenPara.Size = new System.Drawing.Size(379, 46);
            this.btnGenPara.TabIndex = 2;
            this.btnGenPara.Text = "Sinh Ngẫu Nhiên";
            this.btnGenPara.UseVisualStyleBackColor = false;
            this.btnGenPara.Click += new System.EventHandler(this.btnGenPara_Click);
            // 
            // txtCreatePublicKeyY
            // 
            this.txtCreatePublicKeyY.BackColor = System.Drawing.Color.White;
            this.txtCreatePublicKeyY.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCreatePublicKeyY.Location = new System.Drawing.Point(18, 553);
            this.txtCreatePublicKeyY.Name = "txtCreatePublicKeyY";
            this.txtCreatePublicKeyY.ReadOnly = true;
            this.txtCreatePublicKeyY.Size = new System.Drawing.Size(367, 30);
            this.txtCreatePublicKeyY.TabIndex = 3;
            // 
            // txtPrivateA
            // 
            this.txtPrivateA.BackColor = System.Drawing.Color.White;
            this.txtPrivateA.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrivateA.Location = new System.Drawing.Point(18, 381);
            this.txtPrivateA.Name = "txtPrivateA";
            this.txtPrivateA.Size = new System.Drawing.Size(379, 30);
            this.txtPrivateA.TabIndex = 5;
            // 
            // txtG
            // 
            this.txtG.BackColor = System.Drawing.Color.White;
            this.txtG.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtG.Location = new System.Drawing.Point(18, 312);
            this.txtG.Name = "txtG";
            this.txtG.Size = new System.Drawing.Size(378, 30);
            this.txtG.TabIndex = 6;
            // 
            // txtPrimeQ
            // 
            this.txtPrimeQ.BackColor = System.Drawing.Color.White;
            this.txtPrimeQ.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrimeQ.Location = new System.Drawing.Point(18, 238);
            this.txtPrimeQ.Name = "txtPrimeQ";
            this.txtPrimeQ.Size = new System.Drawing.Size(379, 30);
            this.txtPrimeQ.TabIndex = 7;
            // 
            // txtPrimeP
            // 
            this.txtPrimeP.BackColor = System.Drawing.Color.White;
            this.txtPrimeP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrimeP.Location = new System.Drawing.Point(18, 168);
            this.txtPrimeP.Name = "txtPrimeP";
            this.txtPrimeP.Size = new System.Drawing.Size(378, 30);
            this.txtPrimeP.TabIndex = 8;
            // 
            // lblPublicKeyY
            // 
            this.lblPublicKeyY.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPublicKeyY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPublicKeyY.Location = new System.Drawing.Point(18, 525);
            this.lblPublicKeyY.Name = "lblPublicKeyY";
            this.lblPublicKeyY.Size = new System.Drawing.Size(262, 23);
            this.lblPublicKeyY.TabIndex = 9;
            this.lblPublicKeyY.Text = "Khoá công khai y = g^a mod p";
            // 
            // lblPrivateKeyA
            // 
            this.lblPrivateKeyA.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPrivateKeyA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrivateKeyA.Location = new System.Drawing.Point(18, 355);
            this.lblPrivateKeyA.Name = "lblPrivateKeyA";
            this.lblPrivateKeyA.Size = new System.Drawing.Size(175, 23);
            this.lblPrivateKeyA.TabIndex = 10;
            this.lblPrivateKeyA.Text = "Khoá bí mật a ∈ Zq";
            // 
            // lblG
            // 
            this.lblG.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblG.Location = new System.Drawing.Point(18, 286);
            this.lblG.Name = "lblG";
            this.lblG.Size = new System.Drawing.Size(145, 23);
            this.lblG.TabIndex = 11;
            this.lblG.Text = "Phần tử sinh g";
            // 
            // lblPrimeQ
            // 
            this.lblPrimeQ.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPrimeQ.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrimeQ.Location = new System.Drawing.Point(18, 212);
            this.lblPrimeQ.Name = "lblPrimeQ";
            this.lblPrimeQ.Size = new System.Drawing.Size(227, 23);
            this.lblPrimeQ.TabIndex = 12;
            this.lblPrimeQ.Text = "Ước nguyên tố q của (p - 1)";
            // 
            // lblPrimeP
            // 
            this.lblPrimeP.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblPrimeP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPrimeP.Location = new System.Drawing.Point(18, 142);
            this.lblPrimeP.Name = "lblPrimeP";
            this.lblPrimeP.Size = new System.Drawing.Size(166, 23);
            this.lblPrimeP.TabIndex = 13;
            this.lblPrimeP.Text = "Số nguyên tố p";
            // 
            // lblKeyGenTitle
            // 
            this.lblKeyGenTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblKeyGenTitle.ForeColor = System.Drawing.Color.Black;
            this.lblKeyGenTitle.Location = new System.Drawing.Point(108, 15);
            this.lblKeyGenTitle.Name = "lblKeyGenTitle";
            this.lblKeyGenTitle.Size = new System.Drawing.Size(207, 45);
            this.lblKeyGenTitle.TabIndex = 14;
            this.lblKeyGenTitle.Text = "TẠO KHOÁ";
            this.lblKeyGenTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlVerify
            // 
            this.pnlVerify.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlVerify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVerify.Controls.Add(this.lblEnterSignature);
            this.pnlVerify.Controls.Add(this.txtVerifyResult);
            this.pnlVerify.Controls.Add(this.txtImportedPublicKeyPath);
            this.pnlVerify.Controls.Add(this.txtImportedSignaturePath);
            this.pnlVerify.Controls.Add(this.txtVerifyPublicKeyY);
            this.pnlVerify.Controls.Add(this.txtVerifyE);
            this.pnlVerify.Controls.Add(this.txtVerifyS);
            this.pnlVerify.Controls.Add(this.txtVerifyMessageM);
            this.pnlVerify.Controls.Add(this.txtVerifyMsgPath);
            this.pnlVerify.Controls.Add(this.btnImportPublicKeyY);
            this.pnlVerify.Controls.Add(this.btnImportSignature);
            this.pnlVerify.Controls.Add(this.btnVerifySignature);
            this.pnlVerify.Controls.Add(this.btnImportVerifyMsg);
            this.pnlVerify.Controls.Add(this.lblVerifyResult);
            this.pnlVerify.Controls.Add(this.lblVerifyPublicKeyY);
            this.pnlVerify.Controls.Add(this.lblVerifyE);
            this.pnlVerify.Controls.Add(this.lblVerifyS);
            this.pnlVerify.Controls.Add(this.lblVerifyMessageM);
            this.pnlVerify.Controls.Add(this.lblVerifyTitle);
            this.pnlVerify.Location = new System.Drawing.Point(942, 20);
            this.pnlVerify.Name = "pnlVerify";
            this.pnlVerify.Padding = new System.Windows.Forms.Padding(15);
            this.pnlVerify.Size = new System.Drawing.Size(448, 693);
            this.pnlVerify.TabIndex = 2;
            // 
            // lblEnterSignature
            // 
            this.lblEnterSignature.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblEnterSignature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEnterSignature.Location = new System.Drawing.Point(23, 355);
            this.lblEnterSignature.Name = "lblEnterSignature";
            this.lblEnterSignature.Size = new System.Drawing.Size(138, 23);
            this.lblEnterSignature.TabIndex = 18;
            this.lblEnterSignature.Text = "Nhập chữ ký";
            // 
            // txtVerifyResult
            // 
            this.txtVerifyResult.BackColor = System.Drawing.Color.White;
            this.txtVerifyResult.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyResult.Location = new System.Drawing.Point(116, 628);
            this.txtVerifyResult.Name = "txtVerifyResult";
            this.txtVerifyResult.ReadOnly = true;
            this.txtVerifyResult.Size = new System.Drawing.Size(290, 30);
            this.txtVerifyResult.TabIndex = 0;
            // 
            // txtImportedPublicKeyPath
            // 
            this.txtImportedPublicKeyPath.BackColor = System.Drawing.Color.White;
            this.txtImportedPublicKeyPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImportedPublicKeyPath.Location = new System.Drawing.Point(27, 267);
            this.txtImportedPublicKeyPath.Name = "txtImportedPublicKeyPath";
            this.txtImportedPublicKeyPath.ReadOnly = true;
            this.txtImportedPublicKeyPath.Size = new System.Drawing.Size(249, 30);
            this.txtImportedPublicKeyPath.TabIndex = 1;
            // 
            // txtImportedSignaturePath
            // 
            this.txtImportedSignaturePath.BackColor = System.Drawing.Color.White;
            this.txtImportedSignaturePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImportedSignaturePath.Location = new System.Drawing.Point(27, 381);
            this.txtImportedSignaturePath.Name = "txtImportedSignaturePath";
            this.txtImportedSignaturePath.ReadOnly = true;
            this.txtImportedSignaturePath.Size = new System.Drawing.Size(247, 30);
            this.txtImportedSignaturePath.TabIndex = 2;
            // 
            // txtVerifyPublicKeyY
            // 
            this.txtVerifyPublicKeyY.BackColor = System.Drawing.Color.White;
            this.txtVerifyPublicKeyY.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyPublicKeyY.Location = new System.Drawing.Point(27, 312);
            this.txtVerifyPublicKeyY.Name = "txtVerifyPublicKeyY";
            this.txtVerifyPublicKeyY.Size = new System.Drawing.Size(379, 30);
            this.txtVerifyPublicKeyY.TabIndex = 3;
            // 
            // txtVerifyE
            // 
            this.txtVerifyE.BackColor = System.Drawing.Color.White;
            this.txtVerifyE.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyE.Location = new System.Drawing.Point(27, 448);
            this.txtVerifyE.Name = "txtVerifyE";
            this.txtVerifyE.Size = new System.Drawing.Size(379, 30);
            this.txtVerifyE.TabIndex = 4;
            // 
            // txtVerifyS
            // 
            this.txtVerifyS.BackColor = System.Drawing.Color.White;
            this.txtVerifyS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyS.Location = new System.Drawing.Point(27, 507);
            this.txtVerifyS.Name = "txtVerifyS";
            this.txtVerifyS.Size = new System.Drawing.Size(379, 30);
            this.txtVerifyS.TabIndex = 5;
            // 
            // txtVerifyMessageM
            // 
            this.txtVerifyMessageM.BackColor = System.Drawing.Color.White;
            this.txtVerifyMessageM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyMessageM.Location = new System.Drawing.Point(27, 142);
            this.txtVerifyMessageM.Multiline = true;
            this.txtVerifyMessageM.Name = "txtVerifyMessageM";
            this.txtVerifyMessageM.Size = new System.Drawing.Size(379, 80);
            this.txtVerifyMessageM.TabIndex = 6;
            // 
            // txtVerifyMsgPath
            // 
            this.txtVerifyMsgPath.BackColor = System.Drawing.Color.White;
            this.txtVerifyMsgPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtVerifyMsgPath.Location = new System.Drawing.Point(27, 106);
            this.txtVerifyMsgPath.Name = "txtVerifyMsgPath";
            this.txtVerifyMsgPath.ReadOnly = true;
            this.txtVerifyMsgPath.Size = new System.Drawing.Size(253, 30);
            this.txtVerifyMsgPath.TabIndex = 7;
            // 
            // btnImportPublicKeyY
            // 
            this.btnImportPublicKeyY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnImportPublicKeyY.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportPublicKeyY.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnImportPublicKeyY.ForeColor = System.Drawing.Color.White;
            this.btnImportPublicKeyY.Location = new System.Drawing.Point(286, 267);
            this.btnImportPublicKeyY.Name = "btnImportPublicKeyY";
            this.btnImportPublicKeyY.Size = new System.Drawing.Size(120, 30);
            this.btnImportPublicKeyY.TabIndex = 8;
            this.btnImportPublicKeyY.Text = "Nhập khóa";
            this.btnImportPublicKeyY.UseVisualStyleBackColor = false;
            this.btnImportPublicKeyY.Click += new System.EventHandler(this.btnImportPublicKeyY_Click);
            // 
            // btnImportSignature
            // 
            this.btnImportSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnImportSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSignature.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnImportSignature.ForeColor = System.Drawing.Color.White;
            this.btnImportSignature.Location = new System.Drawing.Point(280, 381);
            this.btnImportSignature.Name = "btnImportSignature";
            this.btnImportSignature.Size = new System.Drawing.Size(126, 30);
            this.btnImportSignature.TabIndex = 9;
            this.btnImportSignature.Text = "Nhập chữ ký";
            this.btnImportSignature.UseVisualStyleBackColor = false;
            this.btnImportSignature.Click += new System.EventHandler(this.btnImportSignature_Click);
            // 
            // btnVerifySignature
            // 
            this.btnVerifySignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnVerifySignature.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnVerifySignature.FlatAppearance.BorderSize = 3;
            this.btnVerifySignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifySignature.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVerifySignature.ForeColor = System.Drawing.Color.White;
            this.btnVerifySignature.Location = new System.Drawing.Point(27, 567);
            this.btnVerifySignature.Name = "btnVerifySignature";
            this.btnVerifySignature.Size = new System.Drawing.Size(379, 46);
            this.btnVerifySignature.TabIndex = 10;
            this.btnVerifySignature.Text = "Xác Thực Chữ Ký";
            this.btnVerifySignature.UseVisualStyleBackColor = false;
            this.btnVerifySignature.Click += new System.EventHandler(this.btnVerifySignature_Click);
            // 
            // btnImportVerifyMsg
            // 
            this.btnImportVerifyMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnImportVerifyMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportVerifyMsg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnImportVerifyMsg.ForeColor = System.Drawing.Color.White;
            this.btnImportVerifyMsg.Location = new System.Drawing.Point(286, 105);
            this.btnImportVerifyMsg.Name = "btnImportVerifyMsg";
            this.btnImportVerifyMsg.Size = new System.Drawing.Size(120, 30);
            this.btnImportVerifyMsg.TabIndex = 11;
            this.btnImportVerifyMsg.Text = "Nhập từ file";
            this.btnImportVerifyMsg.UseVisualStyleBackColor = false;
            this.btnImportVerifyMsg.Click += new System.EventHandler(this.btnImportVerifyMsg_Click);
            // 
            // lblVerifyResult
            // 
            this.lblVerifyResult.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblVerifyResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerifyResult.Location = new System.Drawing.Point(23, 631);
            this.lblVerifyResult.Name = "lblVerifyResult";
            this.lblVerifyResult.Size = new System.Drawing.Size(100, 23);
            this.lblVerifyResult.TabIndex = 12;
            this.lblVerifyResult.Text = "Kết quả:";
            // 
            // lblVerifyPublicKeyY
            // 
            this.lblVerifyPublicKeyY.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblVerifyPublicKeyY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerifyPublicKeyY.Location = new System.Drawing.Point(23, 241);
            this.lblVerifyPublicKeyY.Name = "lblVerifyPublicKeyY";
            this.lblVerifyPublicKeyY.Size = new System.Drawing.Size(203, 23);
            this.lblVerifyPublicKeyY.TabIndex = 13;
            this.lblVerifyPublicKeyY.Text = "Nhập khóa công khai y";
            // 
            // lblVerifyE
            // 
            this.lblVerifyE.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblVerifyE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerifyE.Location = new System.Drawing.Point(23, 422);
            this.lblVerifyE.Name = "lblVerifyE";
            this.lblVerifyE.Size = new System.Drawing.Size(100, 23);
            this.lblVerifyE.TabIndex = 14;
            this.lblVerifyE.Text = "Giá trị  e";
            // 
            // lblVerifyS
            // 
            this.lblVerifyS.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblVerifyS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerifyS.Location = new System.Drawing.Point(23, 481);
            this.lblVerifyS.Name = "lblVerifyS";
            this.lblVerifyS.Size = new System.Drawing.Size(100, 23);
            this.lblVerifyS.TabIndex = 15;
            this.lblVerifyS.Text = "Giá trị s";
            // 
            // lblVerifyMessageM
            // 
            this.lblVerifyMessageM.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblVerifyMessageM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVerifyMessageM.Location = new System.Drawing.Point(23, 80);
            this.lblVerifyMessageM.Name = "lblVerifyMessageM";
            this.lblVerifyMessageM.Size = new System.Drawing.Size(235, 23);
            this.lblVerifyMessageM.TabIndex = 16;
            this.lblVerifyMessageM.Text = "Thông điệp  m";
            // 
            // lblVerifyTitle
            // 
            this.lblVerifyTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblVerifyTitle.ForeColor = System.Drawing.Color.Black;
            this.lblVerifyTitle.Location = new System.Drawing.Point(101, 15);
            this.lblVerifyTitle.Name = "lblVerifyTitle";
            this.lblVerifyTitle.Size = new System.Drawing.Size(251, 37);
            this.lblVerifyTitle.TabIndex = 17;
            this.lblVerifyTitle.Text = "XÁC THỰC CHỮ KÝ";
            this.lblVerifyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSignature
            // 
            this.lblSignature.Location = new System.Drawing.Point(0, 0);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(100, 23);
            this.lblSignature.TabIndex = 0;
            // 
            // pnlSign
            // 
            this.pnlSign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSign.Controls.Add(this.txtSignE);
            this.pnlSign.Controls.Add(this.txtSignS);
            this.pnlSign.Controls.Add(this.txtK);
            this.pnlSign.Controls.Add(this.txtSignMessageM);
            this.pnlSign.Controls.Add(this.txtImportedSignMsgPath);
            this.pnlSign.Controls.Add(this.txtExportedSignaturePath);
            this.pnlSign.Controls.Add(this.btnImportSignMsg);
            this.pnlSign.Controls.Add(this.btnCreateSignature);
            this.pnlSign.Controls.Add(this.btnExportSignature);
            this.pnlSign.Controls.Add(this.lblSignE);
            this.pnlSign.Controls.Add(this.lblSignS);
            this.pnlSign.Controls.Add(this.lblK);
            this.pnlSign.Controls.Add(this.lblSignMessageM);
            this.pnlSign.Controls.Add(this.lblSignTitle);
            this.pnlSign.Location = new System.Drawing.Point(465, 20);
            this.pnlSign.Name = "pnlSign";
            this.pnlSign.Padding = new System.Windows.Forms.Padding(15);
            this.pnlSign.Size = new System.Drawing.Size(458, 693);
            this.pnlSign.TabIndex = 1;
            // 
            // txtSignE
            // 
            this.txtSignE.BackColor = System.Drawing.Color.White;
            this.txtSignE.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSignE.Location = new System.Drawing.Point(30, 486);
            this.txtSignE.Name = "txtSignE";
            this.txtSignE.ReadOnly = true;
            this.txtSignE.Size = new System.Drawing.Size(378, 30);
            this.txtSignE.TabIndex = 0;
            // 
            // txtSignS
            // 
            this.txtSignS.BackColor = System.Drawing.Color.White;
            this.txtSignS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSignS.Location = new System.Drawing.Point(30, 554);
            this.txtSignS.Name = "txtSignS";
            this.txtSignS.ReadOnly = true;
            this.txtSignS.Size = new System.Drawing.Size(378, 30);
            this.txtSignS.TabIndex = 1;
            // 
            // txtK
            // 
            this.txtK.BackColor = System.Drawing.Color.White;
            this.txtK.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtK.Location = new System.Drawing.Point(30, 286);
            this.txtK.Name = "txtK";
            this.txtK.ReadOnly = true;
            this.txtK.Size = new System.Drawing.Size(378, 30);
            this.txtK.TabIndex = 2;
            // 
            // txtSignMessageM
            // 
            this.txtSignMessageM.BackColor = System.Drawing.Color.White;
            this.txtSignMessageM.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSignMessageM.Location = new System.Drawing.Point(30, 142);
            this.txtSignMessageM.Multiline = true;
            this.txtSignMessageM.Name = "txtSignMessageM";
            this.txtSignMessageM.Size = new System.Drawing.Size(378, 80);
            this.txtSignMessageM.TabIndex = 3;
            // 
            // txtImportedSignMsgPath
            // 
            this.txtImportedSignMsgPath.BackColor = System.Drawing.Color.White;
            this.txtImportedSignMsgPath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtImportedSignMsgPath.Location = new System.Drawing.Point(30, 106);
            this.txtImportedSignMsgPath.Name = "txtImportedSignMsgPath";
            this.txtImportedSignMsgPath.ReadOnly = true;
            this.txtImportedSignMsgPath.Size = new System.Drawing.Size(252, 30);
            this.txtImportedSignMsgPath.TabIndex = 4;
            // 
            // txtExportedSignaturePath
            // 
            this.txtExportedSignaturePath.BackColor = System.Drawing.Color.White;
            this.txtExportedSignaturePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtExportedSignaturePath.Location = new System.Drawing.Point(30, 602);
            this.txtExportedSignaturePath.Name = "txtExportedSignaturePath";
            this.txtExportedSignaturePath.ReadOnly = true;
            this.txtExportedSignaturePath.Size = new System.Drawing.Size(263, 30);
            this.txtExportedSignaturePath.TabIndex = 5;
            // 
            // btnImportSignMsg
            // 
            this.btnImportSignMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnImportSignMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSignMsg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnImportSignMsg.ForeColor = System.Drawing.Color.White;
            this.btnImportSignMsg.Location = new System.Drawing.Point(288, 106);
            this.btnImportSignMsg.Name = "btnImportSignMsg";
            this.btnImportSignMsg.Size = new System.Drawing.Size(120, 30);
            this.btnImportSignMsg.TabIndex = 6;
            this.btnImportSignMsg.Text = "Nhập từ file";
            this.btnImportSignMsg.UseVisualStyleBackColor = false;
            this.btnImportSignMsg.Click += new System.EventHandler(this.btnImportSignMsg_Click);
            // 
            // btnCreateSignature
            // 
            this.btnCreateSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCreateSignature.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCreateSignature.FlatAppearance.BorderSize = 3;
            this.btnCreateSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSignature.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateSignature.ForeColor = System.Drawing.Color.White;
            this.btnCreateSignature.Location = new System.Drawing.Point(30, 359);
            this.btnCreateSignature.Name = "btnCreateSignature";
            this.btnCreateSignature.Size = new System.Drawing.Size(378, 46);
            this.btnCreateSignature.TabIndex = 7;
            this.btnCreateSignature.Text = "Tạo Chữ Ký";
            this.btnCreateSignature.UseVisualStyleBackColor = false;
            this.btnCreateSignature.Click += new System.EventHandler(this.btnCreateSignature_Click);
            // 
            // btnExportSignature
            // 
            this.btnExportSignature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnExportSignature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSignature.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExportSignature.ForeColor = System.Drawing.Color.White;
            this.btnExportSignature.Location = new System.Drawing.Point(299, 601);
            this.btnExportSignature.Name = "btnExportSignature";
            this.btnExportSignature.Size = new System.Drawing.Size(109, 30);
            this.btnExportSignature.TabIndex = 8;
            this.btnExportSignature.Text = "Xuất chữ ký";
            this.btnExportSignature.UseVisualStyleBackColor = false;
            this.btnExportSignature.Click += new System.EventHandler(this.btnExportSignature_Click);
            // 
            // lblSignE
            // 
            this.lblSignE.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblSignE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSignE.Location = new System.Drawing.Point(30, 460);
            this.lblSignE.Name = "lblSignE";
            this.lblSignE.Size = new System.Drawing.Size(100, 23);
            this.lblSignE.TabIndex = 9;
            this.lblSignE.Text = "Giá trị e";
            // 
            // lblSignS
            // 
            this.lblSignS.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblSignS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSignS.Location = new System.Drawing.Point(30, 528);
            this.lblSignS.Name = "lblSignS";
            this.lblSignS.Size = new System.Drawing.Size(100, 23);
            this.lblSignS.TabIndex = 10;
            this.lblSignS.Text = "Giá trị  s";
            // 
            // lblK
            // 
            this.lblK.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblK.Location = new System.Drawing.Point(30, 260);
            this.lblK.Name = "lblK";
            this.lblK.Size = new System.Drawing.Size(121, 23);
            this.lblK.TabIndex = 11;
            this.lblK.Text = "Giá trị k ∈ Zq";
            // 
            // lblSignMessageM
            // 
            this.lblSignMessageM.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblSignMessageM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSignMessageM.Location = new System.Drawing.Point(30, 80);
            this.lblSignMessageM.Name = "lblSignMessageM";
            this.lblSignMessageM.Size = new System.Drawing.Size(173, 23);
            this.lblSignMessageM.TabIndex = 12;
            this.lblSignMessageM.Text = "Thông điệp m";
            // 
            // lblSignTitle
            // 
            this.lblSignTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblSignTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSignTitle.Location = new System.Drawing.Point(139, 15);
            this.lblSignTitle.Name = "lblSignTitle";
            this.lblSignTitle.Size = new System.Drawing.Size(177, 37);
            this.lblSignTitle.TabIndex = 13;
            this.lblSignTitle.Text = "TẠO CHỮ KÝ";
            this.lblSignTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1402, 725);
            this.Controls.Add(this.pnlSign);
            this.Controls.Add(this.pnlVerify);
            this.Controls.Add(this.pnlKeyGen);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1394, 739);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình chữ ký số Schnorr";
            this.pnlKeyGen.ResumeLayout(false);
            this.pnlKeyGen.PerformLayout();
            this.pnlVerify.ResumeLayout(false);
            this.pnlVerify.PerformLayout();
            this.pnlSign.ResumeLayout(false);
            this.pnlSign.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKeyGen;
        private System.Windows.Forms.TextBox txtExportedKeyPath;
        private System.Windows.Forms.Button btnExportPublicKey;
        private System.Windows.Forms.Button btnGenPara;
        private System.Windows.Forms.TextBox txtCreatePublicKeyY;
        private System.Windows.Forms.TextBox txtPrivateA;
        private System.Windows.Forms.TextBox txtG;
        private System.Windows.Forms.TextBox txtPrimeQ;
        private System.Windows.Forms.TextBox txtPrimeP;
        private System.Windows.Forms.Label lblPublicKeyY;
        private System.Windows.Forms.Label lblPrivateKeyA;
        private System.Windows.Forms.Label lblG;
        private System.Windows.Forms.Label lblPrimeQ;
        private System.Windows.Forms.Label lblPrimeP;
        private System.Windows.Forms.Label lblKeyGenTitle;
        private System.Windows.Forms.Panel pnlVerify;
        private System.Windows.Forms.Button btnImportPublicKeyY;
        private System.Windows.Forms.TextBox txtImportedSignaturePath;
        private System.Windows.Forms.Button btnImportSignature;
        private System.Windows.Forms.Button btnVerifySignature;
        private System.Windows.Forms.TextBox txtVerifyPublicKeyY;
        private System.Windows.Forms.TextBox txtVerifyE;
        private System.Windows.Forms.TextBox txtVerifyS;
        private System.Windows.Forms.TextBox txtVerifyMessageM;
        private System.Windows.Forms.TextBox txtVerifyMsgPath;
        private System.Windows.Forms.Button btnImportVerifyMsg;
        private System.Windows.Forms.Label lblVerifyPublicKeyY;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblVerifyE;
        private System.Windows.Forms.Label lblVerifyS;
        private System.Windows.Forms.Label lblVerifyMessageM;
        private System.Windows.Forms.Label lblVerifyTitle;
        private System.Windows.Forms.Panel pnlSign;
        private System.Windows.Forms.Button btnCreateSignature;
        private System.Windows.Forms.TextBox txtExportedSignaturePath;
        private System.Windows.Forms.TextBox txtSignMessageM;
        private System.Windows.Forms.Button btnExportSignature;
        private System.Windows.Forms.TextBox txtSignE;
        private System.Windows.Forms.TextBox txtSignS;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.TextBox txtImportedSignMsgPath;
        private System.Windows.Forms.Button btnImportSignMsg;
        private System.Windows.Forms.Label lblSignE;
        private System.Windows.Forms.Label lblSignS;
        private System.Windows.Forms.Label lblSignTitle;
        private System.Windows.Forms.Label lblK;
        private System.Windows.Forms.Label lblSignMessageM;
        private System.Windows.Forms.Button btnCreatePublicKey;
        private System.Windows.Forms.Label lblEnterSignature;
        private System.Windows.Forms.TextBox txtImportedPublicKeyPath;
        private System.Windows.Forms.TextBox txtVerifyResult;
        private System.Windows.Forms.Label lblVerifyResult;
    }
}
