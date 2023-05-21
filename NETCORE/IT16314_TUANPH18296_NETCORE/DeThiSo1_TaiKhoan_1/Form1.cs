using DeThiSo1_TaiKhoan_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeThiSo1_TaiKhoan_1
{
    public partial class Form1 : Form
    {
        private Servicesssss _sv;
        private TaiKhoan _taikhoansss;
        public Form1()
        {
            _sv = new Servicesssss();
            InitializeComponent();
            LoadCbx();
            LoadDataView();
        }
        void LoadCbx()
        {
            foreach (var x in _sv.GetlstLoaitaikhoan())
            {
                cbx_Loc.Items.Add(x.TenTk);
                cbx_LocTenTK.Items.Add(x.TenTk);
            }
            cbx_Loc.SelectedIndex = 0;
            cbx_LocTenTK.SelectedIndex = 0;
        }
        void LoadDataView()
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in _sv.GetlstTaikhoan())
            {
                var loaitk = _sv.GetlstLoaitaikhoan().FirstOrDefault(c => c.Id == x.IdChucVu);
                dgr_Table.Rows.Add(x.TenTk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", loaitk.MaTk, loaitk.TenTk, x.Id);
            }
        }

        private void dgr_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (_sv.GetlstTaikhoan().Count == 0 || rd == -1) return;
            _taikhoansss = _sv.GetlstTaikhoan().FirstOrDefault(c => c.Id == Convert.ToInt32(dgr_Table.Rows[rd].Cells[6].Value.ToString()));

            txt_TenTK.Text = dgr_Table.Rows[rd].Cells[0].Value.ToString();
            txt_Matkhau.Text = dgr_Table.Rows[rd].Cells[1].Value.ToString();
            rbtn_Nam.Checked = dgr_Table.Rows[rd].Cells[2].Value.ToString() == "Nam" ? true : false;
            rbtn_Nu.Checked = dgr_Table.Rows[rd].Cells[2].Value.ToString() == "Nữ" ? true : false;
            cbx_Hoatdong.Checked = dgr_Table.Rows[rd].Cells[3].Value.ToString() == "Hoạt động" ? true : false;
            cbx_Khonghoatdong.Checked = dgr_Table.Rows[rd].Cells[3].Value.ToString() == "Không hoạt động" ? true : false;
            cbx_Loc.Text = dgr_Table.Rows[rd].Cells[5].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult cn;

            TaiKhoan tkk = new TaiKhoan();
            tkk.Id = _sv.GetlstTaikhoan().Max(c => c.Id) + 1;
            tkk.TenTk = txt_TenTK.Text;
            tkk.MatKhau = txt_Matkhau.Text;
            tkk.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            tkk.TrangThai = cbx_Hoatdong.Checked ? true : false;
            tkk.IdChucVu = _sv.GetlstLoaitaikhoan().ToList().Where(c => c.TenTk == cbx_Loc.Text).Select(c => c.Id).FirstOrDefault();

            if (_taikhoansss.TenTk == txt_TenTK.Text )
            {
                cn = MessageBox.Show("Tên TK đã tồn tại (ĐANG NULL), Vui lòng nhập lại", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cn = MessageBox.Show(_sv.AddTaiKhoan(tkk), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _sv.GetFromDB();
            LoadDataView();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            _taikhoansss.TenTk = txt_TenTK.Text;
            _taikhoansss.MatKhau = txt_Matkhau.Text;
            _taikhoansss.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            _taikhoansss.GioiTinh = rbtn_Nu.Checked ? 1 : 0;
            _taikhoansss.TrangThai = cbx_Hoatdong.Checked ? true : false;
            _taikhoansss.TrangThai = cbx_Khonghoatdong.Checked ? true : false;
            _taikhoansss.IdChucVuNavigation = _sv.GetlstLoaitaikhoan().FirstOrDefault(c => c.TenTk == cbx_Loc.Text);

            cn = MessageBox.Show(_sv.UpdateTaiKhoan(_taikhoansss), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _sv.GetFromDB();
            LoadDataView();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show(_sv.RemoveTaiKhoan(_taikhoansss), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _sv.GetFromDB();
            LoadDataView();
        }


        private void cbx_LocTenTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCbxLocTenTK(cbx_LocTenTK.Text);
        }
        void LoadCbxLocTenTK(string loctk)
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            var tempLocTk = _sv.GetlstLoaitaikhoan().FirstOrDefault(c => c.TenTk == cbx_LocTenTK.Text);
            foreach (var x in _sv.GetlstTaikhoan().Where(c => c.IdChucVu == tempLocTk.Id))
            {
                var loaitk = _sv.GetlstLoaitaikhoan().FirstOrDefault(c => c.Id == x.IdChucVu);
                dgr_Table.Rows.Add(x.TenTk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", loaitk.MaTk, loaitk.TenTk, x.Id);
            }
        }

        //Lọc theo y/cầu
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.GioiTinh == 1 || b.GioiTinh == 0)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id }).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            { 
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.GioiTinh == 1)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id}).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            {
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }
        private void rbt_NuLoc_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.GioiTinh == 0)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id }).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            {
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.TrangThai == true)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id }).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            {
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.TrangThai == false)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id }).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            {
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }
        private void cbx_NoneCheck_CheckedChanged(object sender, EventArgs e)
        {
            var locSex = (from a in _sv.GetlstLoaitaikhoan()
                          join b in _sv.GetlstTaikhoan() on a.Id equals b.IdChucVu
                          where (b.TrangThai == false || b.TrangThai == true)
                          select new { a.MaTk, a.TenTk, tentk = b.TenTk, b.MatKhau, b.GioiTinh, b.TrangThai, b.Id }).ToList();
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in locSex)
            {
                dgr_Table.Rows.Add(x.tentk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", x.MaTk, x.TenTk, x.Id);
            }
        }


        private void txt_SearchTen_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataSearchTen(txt_SearchTen.Text);
        }
        void LoadDataSearchTen(string nameee)
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Acc";
            dgr_Table.Columns[1].Name = "Pass";
            dgr_Table.Columns[2].Name = "Sex";
            dgr_Table.Columns[3].Name = "Status";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in _sv.GetlstByName(nameee))
            {
                var loaitk = _sv.GetlstLoaitaikhoan().FirstOrDefault(c => c.Id == x.IdChucVu);
                dgr_Table.Rows.Add(x.TenTk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", loaitk.MaTk, loaitk.TenTk, x.Id);
            }
        }

        private void txt_TenTK_Validating(object sender, CancelEventArgs e)
        {
            DialogResult cn;
            if (txt_TenTK.Text.Length == 0)
            {
                cn = MessageBox.Show("Tên TK không được phép NULL !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (Regex.IsMatch(txt_TenTK.Text, @"[0-9]"))
            {
                e.Cancel = true;
                txt_TenTK.Focus();
                cn = MessageBox.Show("Tên TK không được phép có số !", "Xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
