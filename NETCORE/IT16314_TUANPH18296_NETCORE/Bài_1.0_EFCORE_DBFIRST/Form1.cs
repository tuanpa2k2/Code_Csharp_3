using Bài_1._0_EFCORE_DBFIRST.Models;
using Bài_1._0_EFCORE_DBFIRST.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_1._0_EFCORE_DBFIRST
{
    public partial class Form1 : Form
    {
        private List<AccountsAdo> _lstAccounts;
        private AccountsAdo _accountAdos;
        private AccountService _accountService;
        public Form1()
        {
            InitializeComponent();
            _accountService = new AccountService();
            loadCbx_NamSinh();
            Cach1LoadData();
        }
        void Cach1LoadData()//Cách đã học từ bài tổng quan C#
        {
            var temp = _accountService.GetLstAccountsAdo();

            _lstAccounts = temp;//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(AccountsAdo);
            int slThuocTinh = type.GetProperties().Length;
            dgrid_Account.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrid_Account.Columns[0].Name = "Id";
            dgrid_Account.Columns[1].Name = "Tài Khoản";
            dgrid_Account.Columns[2].Name = "Mật Khẩu";
            dgrid_Account.Columns[3].Name = "Giới Tính";
            dgrid_Account.Columns[4].Name = "Năm Sinh";
            dgrid_Account.Columns[5].Name = "Tuổi";
            dgrid_Account.Columns[6].Name = "Trạng Thái";
            dgrid_Account.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrid_Account.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status == true ? "Hoạt động" : "Không Hoạt động");
            }
        }
        void loadCbx_NamSinh()
        {
            foreach (var x in _accountService.getYearOfBirth())
            {
                cbx_Namsinh.Items.Add(x);
            }
            //Hiển thị giá trị cuối cùng của Combobox trừ đi 10
            cbx_Namsinh.SelectedIndex = _accountService.getYearOfBirth().Length - 10;
        }

        void LoadDataToGridAdoAcc(string acc)
        {
            _lstAccounts = new List<AccountsAdo>();//Khởi tạo mới List
            _lstAccounts = _accountService.GetLstAccountsAdoByAcc(acc);//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(AccountsAdo);
            int slThuocTinh = type.GetProperties().Length;
            dgrid_Account.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrid_Account.Columns[0].Name = "Id";
            dgrid_Account.Columns[1].Name = "Tài Khoản";
            dgrid_Account.Columns[2].Name = "Mật Khẩu";
            dgrid_Account.Columns[3].Name = "Giới Tính";
            dgrid_Account.Columns[4].Name = "Năm Sinh";
            dgrid_Account.Columns[5].Name = "Tuổi";
            dgrid_Account.Columns[6].Name = "Trạng Thái";
            dgrid_Account.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrid_Account.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, (bool)x.Status == true? "Hoạt động" : "Không Hoạt động");
            }
        }
        private void txt_Timkiem_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataToGridAdoAcc(txt_Timkiem.Text);
        }

        private void dgrid_Account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == _lstAccounts.Count) return;
            var idAccount = dgrid_Account.Rows[rowIndex].Cells[0].Value;
            _accountAdos = new AccountsAdo();
            _accountAdos = _accountService.finAccount((Guid)idAccount);

            txt_Acc.Text = _accountAdos.Acc;
            txt_Pass.Text = _accountAdos.Pass;
            rbtn_Nam.Checked = _accountAdos.Sex == 1 ? true : false;
            rbtn_Nu.Checked = _accountAdos.Sex == 0 ? true : false;
            cbx_Namsinh.SelectedIndex = cbx_Namsinh.FindString(_accountAdos.YearofBirth.ToString());
            cbo_Hoatdong.Checked = (bool)_accountAdos.Status ? true : false;
            cbo_Khonghoatdong.Checked = _accountAdos.Status == false ? true : false;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            _accountAdos = new AccountsAdo();
            _accountAdos.Acc = txt_Acc.Text;
            _accountAdos.Pass = txt_Pass.Text;
            _accountAdos.Sex = rbtn_Nam.Checked ? 1 : 0;
            _accountAdos.YearofBirth = Convert.ToInt32(cbx_Namsinh.SelectedItem);
            _accountAdos.Status = cbo_Hoatdong.Checked;
            _accountAdos.Status = cbo_Khonghoatdong.Checked;

            _accountService.Insert(_accountAdos);
            MessageBox.Show("Thêm vào thành công !", "Thông báo");
            Cach1LoadData();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn có muốn sửa tài khoản này k ?", "Xác nhận",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                _accountAdos.Acc = txt_Acc.Text;
                _accountAdos.Pass = txt_Pass.Text;
                _accountAdos.Sex = rbtn_Nam.Checked ? 1 : 0;
                _accountAdos.YearofBirth = Convert.ToInt32(cbx_Namsinh.SelectedIndex);
                _accountAdos.Status = cbo_Hoatdong.Checked;
                _accountAdos.Status = cbo_Khonghoatdong.Checked;

                _accountService.Update(_accountAdos);
                MessageBox.Show("Sửa tài khoản thành công !", "Thông báo");
                Cach1LoadData();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn muốn xóa tài khoản này không ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
            }
                //MessageBox.Show(_iserviceCounts.removeAccount(_lstAccounts.Where(c => c.Acc == txt_Acc.Text).
                //                                                  Select(c => c.Id).FirstOrDefault()));
                //_accountService.Delete(_lstAccounts.Where());
                //Cach1LoadData();
        }

    }
}
