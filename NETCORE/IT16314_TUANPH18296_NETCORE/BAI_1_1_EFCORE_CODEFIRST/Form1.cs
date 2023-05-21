using BAI_1_1_EFCORE_CODEFIRST.DB_Context_FPoly;
using BAI_1_1_EFCORE_CODEFIRST.Model;
using BAI_1_1_EFCORE_CODEFIRST.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAI_1_1_EFCORE_CODEFIRST
{
    public partial class Form1 : Form
    {
        private ServiceQl _serviceQl;
        public Form1()
        {
            InitializeComponent();
            _serviceQl = new ServiceQl();
            LoadRole();
            LoadGioiTinh();
            rbtn_NV_Hoatdong.Checked = true;
            LoadGridAccount();
            LoadGridProduct();

        }
        #region 1. Chức năng quản lý tài khoản
        void LoadGioiTinh()
        {
            cbx_Gioitinh.Items.Add("Nam");
            cbx_Gioitinh.Items.Add("Nữ");
            cbx_Gioitinh.SelectedIndex = 0;
        }
        void LoadRole()
        {
            foreach (var x in _serviceQl.GetlstRoles())
            {
                cbx_Loaitaikhoan.Items.Add(x.Name);
            }
            cbx_Loaitaikhoan.SelectedIndex = 0;
        }

        void LoadGridAccount()
        {
            dgrip_DataNhanvien.ColumnCount = 4;
            dgrip_DataNhanvien.Columns[0].Name = "Tài khoản";
            dgrip_DataNhanvien.Columns[1].Name = "Giới tính";
            dgrip_DataNhanvien.Columns[2].Name = "Trạng thái";
            dgrip_DataNhanvien.Columns[3].Name = "Loại TK";
            dgrip_DataNhanvien.Rows.Clear();
            if (_serviceQl.GetlstAccounts().Count < 0) return;
            foreach (var x in _serviceQl.GetlstAccounts())
            {
                dgrip_DataNhanvien.Rows.Add(x.Acc, x.Sex == 1 ? "Nam" : "Nữ", x.Status == true ? "Hoạt động" : "Không hoạt động", 
                                        _serviceQl.GetlstRoles().Where(c => c.Id == x.Roles.Id).Select(c => c.Name).FirstOrDefault());
            }
        }
        void LoadGridAccountByAcc(string acc)
        {
            dgrip_DataNhanvien.ColumnCount = 4;
            dgrip_DataNhanvien.Columns[0].Name = "Tài khoản";
            dgrip_DataNhanvien.Columns[1].Name = "Giới tính";
            dgrip_DataNhanvien.Columns[2].Name = "Trạng thái";
            dgrip_DataNhanvien.Columns[3].Name = "Loại TK";
            dgrip_DataNhanvien.Rows.Clear();
            if (_serviceQl.GetlstAccounts().Count < 0) return;
            foreach (var x in _serviceQl.GetlstAccounts(acc))
            {
                dgrip_DataNhanvien.Rows.Add(x.Acc, x.Sex == 1 ? "Nam" : "Nữ", x.Status == true ? "Hoạt động" : "Không hoạt động",
                    _serviceQl.GetlstRoles().Where(c => c.Id == x.Roles.Id).Select(c => c.Name).FirstOrDefault());
            }
        }
        private void txt_TimkiemNhanvien_TextChanged(object sender, EventArgs e)
        {
            LoadGridAccountByAcc(txt_TimkiemNhanvien.Text.ToLower());
        }

        private void btn_NV_Them_Click(object sender, EventArgs e)
        {
            DialogResult cn; 
            Account acc = new Account
            {
                Acc = txt_Acc.Text,
                Sex = cbx_Gioitinh.Text == "Nam" ? 1 : 0,
                Status = rbtn_NV_Hoatdong.Checked,
                Roles = _serviceQl.GetlstRoles().Where(c => c.Name == cbx_Loaitaikhoan.Text).FirstOrDefault(),
            };
            cn = MessageBox.Show(_serviceQl.AddAccount(acc), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoadGridAccount();
        }
        private void btn_NV_Sua_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            var acc = _serviceQl.GetlstAccounts().FirstOrDefault(c => c.Acc == txt_Acc.Text);
            acc.Sex = cbx_Gioitinh.Text == "Nam" ? 1 : 0;
            acc.Status = rbtn_NV_Hoatdong.Checked;
            acc.Roles = _serviceQl.GetlstRoles().Where(c => c.Name == cbx_Loaitaikhoan.Text).FirstOrDefault();
            cn = MessageBox.Show(_serviceQl.UpdateAccount(acc), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoadGridAccount();
        }
        private void btn_NV_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show(_serviceQl.DeleteAccount(_serviceQl.GetlstAccounts().Where(c => c.Acc == txt_Acc.Text).
                            Select(c => c.Id).FirstOrDefault()), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoadGridAccount();
        }
        private void dgrip_DataNhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == _serviceQl.GetlstAccounts().Count || rowIndex == -1) return;
            txt_Acc.Text = dgrip_DataNhanvien.Rows[rowIndex].Cells[0].Value.ToString();
            var acc = _serviceQl.GetlstAccounts().FirstOrDefault(c => c.Acc == txt_Acc.Text);
            cbx_Gioitinh.Text = dgrip_DataNhanvien.Rows[rowIndex].Cells[1].Value.ToString();
            if (acc.Status == true)
            {
                rbtn_NV_Hoatdong.Checked = true;
            }
            else
            {
                rbtn_NV_Khonghoatdong.Checked = true;
            }
            cbx_Loaitaikhoan.Text = _serviceQl.GetlstRoles().Where(c => c.Id == acc.Roles.Id).Select(c => c.Name)
                .FirstOrDefault();
        }
        #endregion

        #region 2. Chức năng quản lí Sản phẩm
        void LoadGridProduct()
        {
            dgrip_DataSanpham.ColumnCount = 4;
            dgrip_DataSanpham.Columns[0].Name = "Tên sp";
            dgrip_DataSanpham.Columns[1].Name = "Số lượng";
            dgrip_DataSanpham.Columns[2].Name = "Giá";
            dgrip_DataSanpham.Columns[3].Name = "Trạng thái";
            dgrip_DataSanpham.Rows.Clear();
            if (_serviceQl.GetlstProducts().Count < 0) return;
            foreach (var x in _serviceQl.GetlstProducts())
            {
                dgrip_DataSanpham.Rows.Add(x.Name, x.Quantity, x.Price, x.Status == true ? "Hoạt động" : "Không hoạt động");
            }
        }
        //void LoadGridProductBySp(string acc)
        //{
        //    dgrip_DataNhanvien.ColumnCount = 4;
        //    dgrip_DataNhanvien.Columns[0].Name = "Tên sp";
        //    dgrip_DataNhanvien.Columns[1].Name = "Số lượng";
        //    dgrip_DataNhanvien.Columns[2].Name = "Giá";
        //    dgrip_DataNhanvien.Columns[3].Name = "Trạng thái";
        //    dgrip_DataNhanvien.Rows.Clear();
        //    if (_serviceQl.GetlstProducts().Count < 0) return;
        //    foreach (var x in _serviceQl.GetlstProducts(acc))
        //    {
        //        dgrip_DataNhanvien.Rows.Add(x.Name, x.Quantity, x.Price, _serviceQl.GetlstRoles().Where(c => c.Name == Name).FirstOrDefault());
        //    }
        //}

        private void dgrip_DataSanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == _serviceQl.GetlstProducts().Count || rowIndex == -1) return;
            txt_Tensp.Text = dgrip_DataSanpham.Rows[rowIndex].Cells[0].Value.ToString();
            //nb_Soluong.Value.ToString() = dgrip_DataSanpham.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Gia.Text = dgrip_DataSanpham.Rows[rowIndex].Cells[2].Value.ToString();
            rbtn_SP_Hoatdong.Checked = dgrip_DataSanpham.Rows[rowIndex].Cells[3].Value.ToString() == "Hoạt động"? true:false;
            rbtn_SP_Khonghoatdong.Checked = dgrip_DataSanpham.Rows[rowIndex].Cells[3].Value.ToString() == "Không hoạt động"? true:false;
        }
        private void btn_Sp_Them_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            Product product = new Product
            {
                Name = txt_Tensp.Text,
                Quantity = Convert.ToInt32(nb_Soluong.Value),
                Price = Convert.ToInt32(txt_Gia.Text),
                Status = rbtn_SP_Hoatdong.Checked,
            };
            cn = MessageBox.Show(_serviceQl.AddProduct(product), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoadGridProduct();
        }
        private void btn_Sp_Sua_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            var sp = _serviceQl.GetlstProducts().FirstOrDefault(c => c.Name == txt_Tensp.Text);
            sp.Quantity = nb_Soluong.Value.ToString().Length;
            sp.Price = Convert.ToInt32(txt_Gia.Text);
            sp.Status = rbtn_NV_Hoatdong.Checked;
            cn = MessageBox.Show(_serviceQl.UpdateProduct(sp), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void btn_Sp_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show(_serviceQl.DeleteProduct(_serviceQl.GetlstProducts().Where(c => c.Name == txt_Tensp.Text).
                            Select(c => c.Id).FirstOrDefault()), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            LoadGridProduct();
        }
        #endregion

    }
}
