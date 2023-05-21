
namespace DeThiSo3_SinhVien
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgr_Table = new System.Windows.Forms.DataGridView();
            this.cbx_LocTennganh = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.check_Khonghoatdong = new System.Windows.Forms.CheckBox();
            this.check_Hoatdong = new System.Windows.Forms.CheckBox();
            this.cbx_Tennganh = new System.Windows.Forms.ComboBox();
            this.cbx_Namsinh = new System.Windows.Forms.ComboBox();
            this.txt_Tensv = new System.Windows.Forms.TextBox();
            this.txt_Masv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr_Table)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgr_Table);
            this.groupBox1.Controls.Add(this.cbx_LocTennganh);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1137, 324);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sinh viên";
            // 
            // dgr_Table
            // 
            this.dgr_Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgr_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgr_Table.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgr_Table.Location = new System.Drawing.Point(3, 69);
            this.dgr_Table.Name = "dgr_Table";
            this.dgr_Table.RowHeadersWidth = 51;
            this.dgr_Table.RowTemplate.Height = 29;
            this.dgr_Table.Size = new System.Drawing.Size(1131, 252);
            this.dgr_Table.TabIndex = 3;
            this.dgr_Table.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgr_Table_CellClick);
            // 
            // cbx_LocTennganh
            // 
            this.cbx_LocTennganh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_LocTennganh.FormattingEnabled = true;
            this.cbx_LocTennganh.Location = new System.Drawing.Point(701, 27);
            this.cbx_LocTennganh.Name = "cbx_LocTennganh";
            this.cbx_LocTennganh.Size = new System.Drawing.Size(433, 36);
            this.cbx_LocTennganh.TabIndex = 2;
            this.cbx_LocTennganh.SelectedIndexChanged += new System.EventHandler(this.cbx_LocTennganh_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.check_Khonghoatdong);
            this.groupBox2.Controls.Add(this.check_Hoatdong);
            this.groupBox2.Controls.Add(this.cbx_Tennganh);
            this.groupBox2.Controls.Add(this.cbx_Namsinh);
            this.groupBox2.Controls.Add(this.txt_Tensv);
            this.groupBox2.Controls.Add(this.txt_Masv);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(933, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin";
            // 
            // check_Khonghoatdong
            // 
            this.check_Khonghoatdong.AutoSize = true;
            this.check_Khonghoatdong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.check_Khonghoatdong.Location = new System.Drawing.Point(411, 175);
            this.check_Khonghoatdong.Name = "check_Khonghoatdong";
            this.check_Khonghoatdong.Size = new System.Drawing.Size(189, 32);
            this.check_Khonghoatdong.TabIndex = 3;
            this.check_Khonghoatdong.Text = "Không hoạt động";
            this.check_Khonghoatdong.UseVisualStyleBackColor = true;
            // 
            // check_Hoatdong
            // 
            this.check_Hoatdong.AutoSize = true;
            this.check_Hoatdong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.check_Hoatdong.Location = new System.Drawing.Point(229, 175);
            this.check_Hoatdong.Name = "check_Hoatdong";
            this.check_Hoatdong.Size = new System.Drawing.Size(129, 32);
            this.check_Hoatdong.TabIndex = 3;
            this.check_Hoatdong.Text = "Hoạt động";
            this.check_Hoatdong.UseVisualStyleBackColor = true;
            // 
            // cbx_Tennganh
            // 
            this.cbx_Tennganh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_Tennganh.FormattingEnabled = true;
            this.cbx_Tennganh.Location = new System.Drawing.Point(229, 220);
            this.cbx_Tennganh.Name = "cbx_Tennganh";
            this.cbx_Tennganh.Size = new System.Drawing.Size(506, 36);
            this.cbx_Tennganh.TabIndex = 2;
            // 
            // cbx_Namsinh
            // 
            this.cbx_Namsinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbx_Namsinh.FormattingEnabled = true;
            this.cbx_Namsinh.Location = new System.Drawing.Point(229, 127);
            this.cbx_Namsinh.Name = "cbx_Namsinh";
            this.cbx_Namsinh.Size = new System.Drawing.Size(506, 36);
            this.cbx_Namsinh.TabIndex = 2;
            // 
            // txt_Tensv
            // 
            this.txt_Tensv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Tensv.Location = new System.Drawing.Point(229, 80);
            this.txt_Tensv.Name = "txt_Tensv";
            this.txt_Tensv.Size = new System.Drawing.Size(506, 34);
            this.txt_Tensv.TabIndex = 1;
            // 
            // txt_Masv
            // 
            this.txt_Masv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Masv.Location = new System.Drawing.Point(229, 35);
            this.txt_Masv.Name = "txt_Masv";
            this.txt_Masv.Size = new System.Drawing.Size(506, 34);
            this.txt_Masv.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(-232, -41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sv";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(40, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 28);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tên ngành :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(46, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trạng thái :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(49, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Năm sinh :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(79, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 28);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên sv :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(83, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sv :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Xoa);
            this.groupBox3.Controls.Add(this.btn_Sua);
            this.groupBox3.Controls.Add(this.btn_Them);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(933, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 278);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng";
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Xoa.Location = new System.Drawing.Point(39, 169);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(139, 36);
            this.btn_Xoa.TabIndex = 0;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Sua.Location = new System.Drawing.Point(39, 112);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(139, 36);
            this.btn_Sua.TabIndex = 0;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Them.Location = new System.Drawing.Point(39, 57);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(139, 36);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 602);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Đề thi số 3";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgr_Table)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgr_Table;
        private System.Windows.Forms.ComboBox cbx_LocTennganh;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox check_Khonghoatdong;
        private System.Windows.Forms.CheckBox check_Hoatdong;
        private System.Windows.Forms.ComboBox cbx_Tennganh;
        private System.Windows.Forms.ComboBox cbx_Namsinh;
        private System.Windows.Forms.TextBox txt_Tensv;
        private System.Windows.Forms.TextBox txt_Masv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
    }
}

