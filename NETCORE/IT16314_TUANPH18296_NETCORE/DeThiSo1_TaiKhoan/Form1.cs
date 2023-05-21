using DeThiSo1_TaiKhoan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeThiSo1_TaiKhoan
{
    public partial class Form1 : Form
    {
        private Servicess _sv;
        private TaiKhoan _taiKhoansss;
        private List<TaiKhoan> _lstTaikhoans;
        public Form1()
        {
            _sv = new Servicess();
            _taiKhoansss = new TaiKhoan();
            _lstTaikhoans = new List<TaiKhoan>();
            InitializeComponent();
            LoadCbx();
            LoadTable();
        }
        void LoadCbx()
        {
            foreach (var x in _sv.GetlstLoaiTK())
            {
                cbx_Loc.Items.Add(x.TenTk);
                cbx_LocTenTK.Items.Add(x.TenTk);
            }
            cbx_Loc.SelectedIndex = 0;
            cbx_LocTenTK.SelectedIndex = 0;
        }
        void LoadTable()
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Tên TK";
            dgr_Table.Columns[1].Name = "Mật khẩu";
            dgr_Table.Columns[2].Name = "Giới tính";
            dgr_Table.Columns[3].Name = "Trạng thái";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "IDTaikhoan"; //Khóa chính để xóa
            dgr_Table.Columns[6].Visible = false; //Ân khóa chính không hiện trên form
            dgr_Table.Rows.Clear();
            foreach (var x in _sv.GetlstTaiKhoan())
            {
                var chucvu = _sv.GetlstLoaiTK().FirstOrDefault(c =>c.Id == x.IdChucVu);
                dgr_Table.Rows.Add(x.TenTk, x.MatKhau, x.GioiTinh == 1? "Nam":"Nữ", 
                    x.TrangThai == true? "Hoạt động":"Không hoạt động", chucvu.MaTk, chucvu.TenTk, x.Id);
            }
        }

        private void dgr_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == _sv.GetlstTaiKhoan().Count || rd == -1) return;
            _taiKhoansss = _sv.GetlstTaiKhoan().FirstOrDefault
                (c => c.Id == Convert.ToInt32(dgr_Table.Rows[rd].Cells[6].Value.ToString()));
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
            TaiKhoan tks = new TaiKhoan();
            tks.Id = _sv.GetlstTaiKhoan().Max(c =>c.Id) +1;
            tks.TenTk = txt_TenTK.Text;
            tks.MatKhau = txt_Matkhau.Text;
            tks.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            tks.TrangThai = cbx_Hoatdong.Checked ? true : false;
            tks.IdChucVu = _sv.GetlstLoaiTK().ToList().Where(c => c.TenTk == cbx_Loc.Text).Select(c => c.Id).FirstOrDefault();
            MessageBox.Show(_sv.AddTaiKhoan(tks) ,"Thông báo");
            _sv.GetlstFromDB();
            LoadTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _taiKhoansss.TenTk = txt_TenTK.Text;
            _taiKhoansss.MatKhau = txt_Matkhau.Text;
            _taiKhoansss.GioiTinh = rbtn_Nam.Checked ? 1 : 0;
            _taiKhoansss.TrangThai = cbx_Hoatdong.Checked ? true : false;
            _taiKhoansss.IdChucVuNavigation = _sv.GetlstLoaiTK().FirstOrDefault(c => c.TenTk == cbx_Loc.Text);
            MessageBox.Show(_sv.UpdateTaiKhoan(_taiKhoansss), "Thông báo");
            _sv.GetlstFromDB();
            LoadTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_sv.RemoveTaiKhoan(_taiKhoansss), "Thông báo");
            _sv.GetlstFromDB();
            LoadTable();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCbxLocTheoTenTK(cbx_LocTenTK.Text);
        }
        void LoadCbxLocTheoTenTK(string tenTK)
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Tên TK";
            dgr_Table.Columns[1].Name = "Mật khẩu";
            dgr_Table.Columns[2].Name = "Giới tính";
            dgr_Table.Columns[3].Name = "Trạng thái";
            dgr_Table.Columns[4].Name = "Mã TK";
            dgr_Table.Columns[5].Name = "Tên TK";
            dgr_Table.Columns[6].Name = "IDTaikhoan"; //Khóa chính để xóa
            dgr_Table.Columns[6].Visible = false; //Ân khóa chính không hiện trên form
            dgr_Table.Rows.Clear();
            var tempIdChucbu = _sv.GetlstLoaiTK().FirstOrDefault(c =>c.TenTk == cbx_LocTenTK.Text);
            foreach (var x in _sv.GetlstTaiKhoan().Where(c =>c.IdChucVu == tempIdChucbu.Id))
            {
                var chucvu = _sv.GetlstLoaiTK().FirstOrDefault(c => c.Id == x.IdChucVu);
                dgr_Table.Rows.Add(x.TenTk, x.MatKhau, x.GioiTinh == 1 ? "Nam" : "Nữ",
                    x.TrangThai == true ? "Hoạt động" : "Không hoạt động", chucvu.MaTk, chucvu.TenTk, x.Id);
            }
        }
    }
}
