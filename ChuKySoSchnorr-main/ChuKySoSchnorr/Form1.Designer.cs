namespace ChuKySoSchnorr
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            errorMsg = new Label();
            label7 = new Label();
            txtY = new TextBox();
            label6 = new Label();
            btnGeneratePublicKey = new Button();
            txtX = new TextBox();
            label5 = new Label();
            txtG = new TextBox();
            label4 = new Label();
            txtQ = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtP = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label19 = new Label();
            txtSign = new TextBox();
            txtSSign = new TextBox();
            button3 = new Button();
            label8 = new Label();
            txtMGenerate = new TextBox();
            txtRSign = new TextBox();
            label13 = new Label();
            label9 = new Label();
            label14 = new Label();
            txtKSign = new TextBox();
            label10 = new Label();
            btnSign = new Button();
            panel3 = new Panel();
            txtCheckResult = new TextBox();
            label18 = new Label();
            btnCheck = new Button();
            txtSCheck = new TextBox();
            label16 = new Label();
            label15 = new Label();
            txtRCheck = new TextBox();
            button4 = new Button();
            label17 = new Label();
            label11 = new Label();
            txtMCheck = new TextBox();
            label12 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(errorMsg);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtY);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(btnGeneratePublicKey);
            panel1.Controls.Add(txtX);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtG);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtQ);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtP);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(25, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 558);
            panel1.TabIndex = 0;
            // 
            // errorMsg
            // 
            errorMsg.AutoSize = true;
            errorMsg.Location = new Point(11, 398);
            errorMsg.Name = "errorMsg";
            errorMsg.Size = new Size(0, 20);
            errorMsg.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(11, 363);
            label7.Name = "label7";
            label7.Size = new Size(224, 23);
            label7.TabIndex = 12;
            label7.Text = "Lỗi khi tạo tham số và khóa:";
            label7.Click += label7_Click;
            // 
            // txtY
            // 
            txtY.BackColor = SystemColors.ControlLightLight;
            txtY.Location = new Point(165, 327);
            txtY.Name = "txtY";
            txtY.RightToLeft = RightToLeft.Yes;
            txtY.Size = new Size(154, 27);
            txtY.TabIndex = 11;
            txtY.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 330);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 10;
            label6.Text = "Khóa công khai y:";
            label6.Click += label6_Click;
            // 
            // btnGeneratePublicKey
            // 
            btnGeneratePublicKey.BackColor = Color.PaleGreen;
            btnGeneratePublicKey.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeneratePublicKey.Location = new Point(112, 257);
            btnGeneratePublicKey.Name = "btnGeneratePublicKey";
            btnGeneratePublicKey.Size = new Size(113, 46);
            btnGeneratePublicKey.TabIndex = 9;
            btnGeneratePublicKey.Text = "Tạo";
            btnGeneratePublicKey.UseVisualStyleBackColor = false;
            btnGeneratePublicKey.Click += button1_Click;
            // 
            // txtX
            // 
            txtX.Location = new Point(165, 204);
            txtX.Name = "txtX";
            txtX.Size = new Size(154, 27);
            txtX.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 207);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 7;
            label5.Text = "Chọn khóa bí mật x:";
            // 
            // txtG
            // 
            txtG.Location = new Point(165, 156);
            txtG.Name = "txtG";
            txtG.Size = new Size(154, 27);
            txtG.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 159);
            label4.Name = "label4";
            label4.Size = new Size(130, 20);
            label4.TabIndex = 5;
            label4.Text = "Chọn số nguyên g:";
            // 
            // txtQ
            // 
            txtQ.Location = new Point(165, 108);
            txtQ.Name = "txtQ";
            txtQ.Size = new Size(154, 27);
            txtQ.TabIndex = 4;
            txtQ.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 111);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 3;
            label3.Text = "Chọn số nguyên q:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(47, 11);
            label2.Name = "label2";
            label2.Size = new Size(246, 35);
            label2.TabIndex = 2;
            label2.Text = "Tạo tham số và khóa";
            label2.Click += label2_Click;
            // 
            // txtP
            // 
            txtP.Location = new Point(165, 64);
            txtP.Name = "txtP";
            txtP.Size = new Size(154, 27);
            txtP.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 67);
            label1.Name = "label1";
            label1.Size = new Size(148, 20);
            label1.TabIndex = 0;
            label1.Text = "Chọn số nguyên tố p:";
            label1.Click += label1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label19);
            panel2.Controls.Add(txtSign);
            panel2.Controls.Add(txtSSign);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(txtMGenerate);
            panel2.Controls.Add(txtRSign);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(txtKSign);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(btnSign);
            panel2.Location = new Point(388, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(340, 558);
            panel2.TabIndex = 1;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(15, 382);
            label19.Name = "label19";
            label19.Size = new Size(56, 20);
            label19.TabIndex = 29;
            label19.Text = "Chữ ký:";
            // 
            // txtSign
            // 
            txtSign.BackColor = SystemColors.ControlLightLight;
            txtSign.Location = new Point(15, 416);
            txtSign.Multiline = true;
            txtSign.Name = "txtSign";
            txtSign.ReadOnly = true;
            txtSign.Size = new Size(307, 54);
            txtSign.TabIndex = 28;
            // 
            // txtSSign
            // 
            txtSSign.BackColor = SystemColors.ControlLightLight;
            txtSSign.Location = new Point(179, 337);
            txtSSign.Multiline = true;
            txtSSign.Name = "txtSSign";
            txtSSign.Size = new Size(141, 27);
            txtSSign.TabIndex = 18;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ActiveCaption;
            button3.FlatAppearance.BorderSize = 0;
            button3.Location = new Point(232, 59);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(90, 29);
            button3.TabIndex = 27;
            button3.Text = "Chọn file";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 340);
            label8.Name = "label8";
            label8.Size = new Size(149, 20);
            label8.TabIndex = 17;
            label8.Text = "Thành phần thứ hai s:";
            // 
            // txtMGenerate
            // 
            txtMGenerate.Location = new Point(15, 101);
            txtMGenerate.Multiline = true;
            txtMGenerate.Name = "txtMGenerate";
            txtMGenerate.Size = new Size(307, 54);
            txtMGenerate.TabIndex = 26;
            // 
            // txtRSign
            // 
            txtRSign.BackColor = SystemColors.ControlLightLight;
            txtRSign.Location = new Point(179, 293);
            txtRSign.Name = "txtRSign";
            txtRSign.Size = new Size(141, 27);
            txtRSign.TabIndex = 16;
            txtRSign.TextChanged += textBox8_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(100, 11);
            label13.Name = "label13";
            label13.Size = new Size(135, 35);
            label13.TabIndex = 15;
            label13.Text = "Tạo chữ ký";
            label13.Click += label13_Click;
            // 
            // label9
            // 
            label9.Location = new Point(12, 296);
            label9.Name = "label9";
            label9.Size = new Size(161, 40);
            label9.TabIndex = 15;
            label9.Text = "Thành phần thứ nhất r:";
            label9.Click += label9_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 65);
            label14.Name = "label14";
            label14.Size = new Size(213, 20);
            label14.TabIndex = 13;
            label14.Text = "Chọn hoặc nhập thông điệp M:";
            label14.Click += label14_Click;
            // 
            // txtKSign
            // 
            txtKSign.BackColor = SystemColors.ControlLightLight;
            txtKSign.Location = new Point(179, 249);
            txtKSign.Name = "txtKSign";
            txtKSign.Size = new Size(141, 27);
            txtKSign.TabIndex = 14;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 252);
            label10.Name = "label10";
            label10.Size = new Size(117, 20);
            label10.TabIndex = 13;
            label10.Text = "Số ngẫu nhiên k:";
            // 
            // btnSign
            // 
            btnSign.BackColor = Color.PaleGreen;
            btnSign.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSign.Location = new Point(122, 179);
            btnSign.Name = "btnSign";
            btnSign.Size = new Size(113, 46);
            btnSign.TabIndex = 22;
            btnSign.Text = "Tạo";
            btnSign.UseVisualStyleBackColor = false;
            btnSign.Click += button2_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.Controls.Add(txtCheckResult);
            panel3.Controls.Add(label18);
            panel3.Controls.Add(btnCheck);
            panel3.Controls.Add(txtSCheck);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(txtRCheck);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(txtMCheck);
            panel3.Controls.Add(label12);
            panel3.Location = new Point(754, 12);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(340, 558);
            panel3.TabIndex = 1;
            // 
            // txtCheckResult
            // 
            txtCheckResult.BackColor = SystemColors.ControlLightLight;
            txtCheckResult.Location = new Point(14, 478);
            txtCheckResult.Multiline = true;
            txtCheckResult.Name = "txtCheckResult";
            txtCheckResult.ReadOnly = true;
            txtCheckResult.Size = new Size(307, 54);
            txtCheckResult.TabIndex = 35;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(11, 444);
            label18.Name = "label18";
            label18.Size = new Size(63, 20);
            label18.TabIndex = 34;
            label18.Text = "Kết quả:";
            label18.Click += label18_Click;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.PaleGreen;
            btnCheck.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCheck.Location = new Point(111, 382);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(113, 46);
            btnCheck.TabIndex = 28;
            btnCheck.Text = "Kiểm tra";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += btnCheck_Click;
            // 
            // txtSCheck
            // 
            txtSCheck.BackColor = SystemColors.ControlLightLight;
            txtSCheck.Location = new Point(14, 327);
            txtSCheck.Multiline = true;
            txtSCheck.Name = "txtSCheck";
            txtSCheck.Size = new Size(307, 27);
            txtSCheck.TabIndex = 31;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label16.Location = new Point(11, 293);
            label16.Name = "label16";
            label16.Size = new Size(148, 20);
            label16.TabIndex = 30;
            label16.Text = "Thành phần thứ hai s:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(14, 179);
            label15.Name = "label15";
            label15.Size = new Size(165, 20);
            label15.TabIndex = 28;
            label15.Text = "Chọn hoặc nhập chữ ký:";
            label15.Click += label15_Click;
            // 
            // txtRCheck
            // 
            txtRCheck.BackColor = SystemColors.ControlLightLight;
            txtRCheck.Location = new Point(14, 251);
            txtRCheck.Name = "txtRCheck";
            txtRCheck.Size = new Size(303, 27);
            txtRCheck.TabIndex = 29;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ActiveCaption;
            button4.FlatAppearance.BorderSize = 0;
            button4.Location = new Point(231, 59);
            button4.Margin = new Padding(0);
            button4.Name = "button4";
            button4.Size = new Size(90, 29);
            button4.TabIndex = 30;
            button4.Text = "Chọn file";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label17
            // 
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label17.Location = new Point(11, 218);
            label17.Name = "label17";
            label17.Size = new Size(161, 20);
            label17.TabIndex = 28;
            label17.Text = "Thành phần thứ nhất r:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(56, 11);
            label11.Name = "label11";
            label11.Size = new Size(187, 35);
            label11.TabIndex = 13;
            label11.Text = "Kiểm tra chữ ký";
            // 
            // txtMCheck
            // 
            txtMCheck.Location = new Point(14, 101);
            txtMCheck.Multiline = true;
            txtMCheck.Name = "txtMCheck";
            txtMCheck.Size = new Size(307, 54);
            txtMCheck.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 65);
            label12.Name = "label12";
            label12.Size = new Size(213, 20);
            label12.TabIndex = 28;
            label12.Text = "Chọn hoặc nhập thông điệp M:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1118, 582);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chữ ký Schnorr";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private TextBox txtP;
        private Label label1;
        private Label label2;
        private TextBox txtQ;
        private Label label3;
        private TextBox txtG;
        private Label label4;
        private TextBox txtX;
        private Label label5;
        private Button btnGeneratePublicKey;
        private Label label6;
        private TextBox txtY;
        private Label label7;
        private Label label13;
        private Label label14;
        private Button btnSign;
        private TextBox txtMGenerate;
        private Button button3;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label15;
        private Button button4;
        private TextBox txtMCheck;
        private Label label12;
        private TextBox txtSCheck;
        private Label label16;
        private TextBox txtRCheck;
        private Label label17;
        private TextBox txtCheckResult;
        private Label label18;
        private Button btnCheck;
        public TextBox txtSSign;
        private TextBox txtRSign;
        private TextBox txtKSign;
        private Label label19;
        public TextBox txtSign;
        private Label errorMsg;
    }
}
