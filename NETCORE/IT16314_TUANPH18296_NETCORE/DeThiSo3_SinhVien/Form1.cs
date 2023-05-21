using DeThiSo3_SinhVien.Models;
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

namespace DeThiSo3_SinhVien
{
    public partial class Form1 : Form
    {
        private Servicesss _sv;
        private SinhVien _sinhviensss;
        private string erorr = "Thông báo tin không vui ";
        public Form1()
        {
            _sv = new Servicesss();
            InitializeComponent();
            check_Khonghoatdong.Checked = true;
            LoadCbx();
            LoadTable();
        }
        void LoadCbx()
        {
            foreach (var x in _sv.GetYearOfBirth())
            {
                cbx_Namsinh.Items.Add(x);
            }
            cbx_Namsinh.SelectedIndex = _sv.GetYearOfBirth().Length - 10;

            foreach (var x in _sv.GetlistNganh())
            {
                cbx_Tennganh.Items.Add(x.TenNganh);
                cbx_LocTennganh.Items.Add(x.TenNganh);
            }
            cbx_Tennganh.SelectedIndex = 0;
            cbx_LocTennganh.SelectedIndex = 0;
        }
        void LoadTable()
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Mã sv";
            dgr_Table.Columns[1].Name = "Tên sv";
            dgr_Table.Columns[2].Name = "Năm sinh";
            dgr_Table.Columns[3].Name = "Trạng thái";
            dgr_Table.Columns[4].Name = "Mã ngành";
            dgr_Table.Columns[5].Name = "Tên ngành";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            foreach (var x in _sv.GetlstSinhvien())
            {
                var nganh = _sv.GetlistNganh().FirstOrDefault(c => c.Id == x.IdNganh);
                dgr_Table.Rows.Add(x.MaSv, x.TenSv, x.NamSinh, x.TrangThai == true ? "Hoạt động" : "Không hoạt động",
                    nganh.MaNganh, nganh.TenNganh, x.Id);
            }
        }

        private void dgr_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (_sv.GetlstSinhvien().Count == 0 || rd == -1) return;
            _sinhviensss = _sv.GetlstSinhvien().FirstOrDefault(c => c.Id ==
                    Convert.ToInt32(dgr_Table.Rows[rd].Cells[6].Value.ToString()));
            txt_Masv.Text = dgr_Table.Rows[rd].Cells[0].Value.ToString();
            txt_Tensv.Text = dgr_Table.Rows[rd].Cells[1].Value.ToString();
            cbx_Namsinh.Text = dgr_Table.Rows[rd].Cells[2].Value.ToString();
            check_Hoatdong.Checked = dgr_Table.Rows[rd].Cells[3].Value.ToString() == "Hoạt động" ? true : false;
            check_Khonghoatdong.Checked = dgr_Table.Rows[rd].Cells[3].Value.ToString() == "Không hoạt động" ? true : false;
            cbx_Tennganh.Text = dgr_Table.Rows[rd].Cells[5].Value.ToString();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            if (CheckEverthing() == false)
            {
                return ;
            }
            else
            {
                cn = MessageBox.Show("Bạn có chắc muốn thêm sinh viên không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cn == DialogResult.Yes)
                {
                    SinhVien ssv = new SinhVien();
                    ssv.Id = _sv.GetlstSinhvien().Max(c => c.Id) + 1;
                    ssv.MaSv = txt_Masv.Text;
                    ssv.TenSv = txt_Tensv.Text;
                    ssv.NamSinh = cbx_Namsinh.Text;
                    ssv.TrangThai = check_Hoatdong.Checked ? true : false;
                    //if (ssv.TrangThai == true)
                    ssv.IdNganh = _sv.GetlistNganh().ToList().Where(c => c.TenNganh == cbx_Tennganh.Text)
                        .Select(C => C.Id).FirstOrDefault();

                    MessageBox.Show(_sv.AddSinhvien(ssv), "Thông báo");
                    _sv.GetlstDB();
                    LoadTable();
                }
            }
        }
        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn có chắc muốn sửa sinh viên không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                _sinhviensss.MaSv = txt_Masv.Text;
                _sinhviensss.TenSv = txt_Tensv.Text;
                _sinhviensss.NamSinh = cbx_Namsinh.Text;
                _sinhviensss.TrangThai = check_Hoatdong.Checked ? true : false;
                _sinhviensss.TrangThai = check_Khonghoatdong.Checked ? true : false;
                _sinhviensss.IdNganhNavigation = _sv.GetlistNganh().FirstOrDefault(c => c.TenNganh == cbx_Tennganh.Text);



                MessageBox.Show(_sv.UpdateSinhvien(_sinhviensss), "Thông báo");
                _sv.GetlstDB();
                LoadTable();
            }
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn có chắc muốn xóa sinh viên không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                MessageBox.Show(_sv.RemoveSinhvien(_sinhviensss), "Thông báo");
                _sv.GetlstDB();
                LoadTable();
            }
        }
        private void cbx_LocTennganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLocTenNganh(cbx_LocTennganh.Text);
        }
        void LoadLocTenNganh(string acc)
        {
            dgr_Table.ColumnCount = 7;
            dgr_Table.Columns[0].Name = "Mã sv";
            dgr_Table.Columns[1].Name = "Tên sv";
            dgr_Table.Columns[2].Name = "Năm sinh";
            dgr_Table.Columns[3].Name = "Trạng thái";
            dgr_Table.Columns[4].Name = "Mã ngành";
            dgr_Table.Columns[5].Name = "Tên ngành";
            dgr_Table.Columns[6].Name = "ID";
            dgr_Table.Columns[6].Visible = false;
            dgr_Table.Rows.Clear();
            var tempIdNganh = _sv.GetlistNganh().FirstOrDefault(c => c.TenNganh == cbx_LocTennganh.Text);
            foreach (var x in _sv.GetlstSinhvien().Where(c => c.IdNganh == tempIdNganh.Id))
            {
                var nganh = _sv.GetlistNganh().FirstOrDefault(c => c.Id == x.IdNganh);
                dgr_Table.Rows.Add(x.MaSv, x.TenSv, x.NamSinh, x.TrangThai == true ? "Hoạt động" : "Không hoạt động",
                    nganh.MaNganh, nganh.TenNganh, x.Id);
            }
        }

        private bool CheckEverthing()
        {
            DialogResult cn;
            if (_sv.CheckNull(txt_Masv.Text) || _sv.CheckNull(txt_Tensv.Text))
            {
                cn = MessageBox.Show("Mã sv (Tên sv) không trống dữ liệu", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_sv.CheckString(txt_Tensv.Text))
            {
                cn = MessageBox.Show("Tên sv không được nhập số", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_sv.CheckSo(cbx_Namsinh.Text))
            {
                cn = MessageBox.Show("Năm sinh không được nhập chữ", erorr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

    }
}
