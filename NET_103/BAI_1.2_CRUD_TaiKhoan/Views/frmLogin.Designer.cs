
namespace BAI_1._2_CRUD_TaiKhoan.Views
{
    partial class frmLogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txxt_Acc = new System.Windows.Forms.TextBox();
            this.txxt_Pass = new System.Windows.Forms.TextBox();
            this.lbl_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.lbl_DangKi = new System.Windows.Forms.LinkLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_path = new System.Windows.Forms.Label();
            this.btn_OpenData = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài khoản :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu :";
            // 
            // txxt_Acc
            // 
            this.txxt_Acc.Location = new System.Drawing.Point(130, 25);
            this.txxt_Acc.Name = "txxt_Acc";
            this.txxt_Acc.Size = new System.Drawing.Size(332, 27);
            this.txxt_Acc.TabIndex = 2;
            // 
            // txxt_Pass
            // 
            this.txxt_Pass.Location = new System.Drawing.Point(130, 67);
            this.txxt_Pass.Name = "txxt_Pass";
            this.txxt_Pass.PasswordChar = '*';
            this.txxt_Pass.Size = new System.Drawing.Size(332, 27);
            this.txxt_Pass.TabIndex = 3;
            // 
            // lbl_QuenMatKhau
            // 
            this.lbl_QuenMatKhau.AutoSize = true;
            this.lbl_QuenMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_QuenMatKhau.Location = new System.Drawing.Point(311, 112);
            this.lbl_QuenMatKhau.Name = "lbl_QuenMatKhau";
            this.lbl_QuenMatKhau.Size = new System.Drawing.Size(151, 20);
            this.lbl_QuenMatKhau.TabIndex = 4;
            this.lbl_QuenMatKhau.TabStop = true;
            this.lbl_QuenMatKhau.Text = "Quên mật khẩu ?";
            this.lbl_QuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_QuenMatKhau_LinkClicked);
            // 
            // lbl_DangKi
            // 
            this.lbl_DangKi.AutoSize = true;
            this.lbl_DangKi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DangKi.Location = new System.Drawing.Point(374, 142);
            this.lbl_DangKi.Name = "lbl_DangKi";
            this.lbl_DangKi.Size = new System.Drawing.Size(88, 20);
            this.lbl_DangKi.TabIndex = 5;
            this.lbl_DangKi.TabStop = true;
            this.lbl_DangKi.Text = "Đăng kí ?";
            this.lbl_DangKi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_DangKi_LinkClicked);
            // 
            // btn_Login
            // 
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.Location = new System.Drawing.Point(299, 178);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(163, 37);
            this.btn_Login.TabIndex = 6;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lbl_path
            // 
            this.lbl_path.AutoSize = true;
            this.lbl_path.Location = new System.Drawing.Point(147, 283);
            this.lbl_path.Name = "lbl_path";
            this.lbl_path.Size = new System.Drawing.Size(0, 20);
            this.lbl_path.TabIndex = 7;
            // 
            // btn_OpenData
            // 
            this.btn_OpenData.Location = new System.Drawing.Point(5, 231);
            this.btn_OpenData.Name = "btn_OpenData";
            this.btn_OpenData.Size = new System.Drawing.Size(136, 33);
            this.btn_OpenData.TabIndex = 8;
            this.btn_OpenData.Text = "Mở data";
            this.btn_OpenData.UseVisualStyleBackColor = true;
            this.btn_OpenData.Click += new System.EventHandler(this.btn_OpenData_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "Đường dẫn file :";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 315);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_OpenData);
            this.Controls.Add(this.lbl_path);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.lbl_DangKi);
            this.Controls.Add(this.lbl_QuenMatKhau);
            this.Controls.Add(this.txxt_Pass);
            this.Controls.Add(this.txxt_Acc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txxt_Acc;
        private System.Windows.Forms.TextBox txxt_Pass;
        private System.Windows.Forms.LinkLabel lbl_QuenMatKhau;
        private System.Windows.Forms.LinkLabel lbl_DangKi;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lbl_path;
        private System.Windows.Forms.Button btn_OpenData;
        private System.Windows.Forms.Button button1;
    }
}