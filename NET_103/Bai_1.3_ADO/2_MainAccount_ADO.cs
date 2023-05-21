using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_1._3_ADO
{
    public partial class _2_MainAccount_ADO : Form
    {
        private string _sqlConnectionString = @"Data Source=DESKTOP-V4BEME9\SQLEXPRESS01;
                                            Initial Catalog=CSharp3_tuanpa_18296;
                                            Persist Security Info=True;User ID=tuanpa03;Password=2002"; //Chuỗi kết nối csdl
        private ServiceAccount _serviceAccounts;
        private List<Account> _lstAccounts;
        private SqlConnection _conn;
        private SqlCommand _cmd;
        private Account _account;

        public _2_MainAccount_ADO()
        {
            InitializeComponent();
            _account = new Account();
            _serviceAccounts = new ServiceAccount(_sqlConnectionString);
            loadCbx_NamSinh();
            Cach1_LoadData();
        }
        void Cach1_LoadData()
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _serviceAccounts.GetLstAccountsFromDB();   //Lấy List Account
            Type type = typeof(Account); //Đếm số lượng thuộc tính có trong đối tượng
            int slThuocTinh = type.GetProperties().Length;
            dgrip_Account1.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrip_Account1.Columns[0].Name = "Id";
            dgrip_Account1.Columns[1].Name = "Tài Khoản";
            dgrip_Account1.Columns[2].Name = "Mật Khẩu";
            dgrip_Account1.Columns[3].Name = "Giới Tính";
            dgrip_Account1.Columns[4].Name = "Năm Sinh";
            dgrip_Account1.Columns[5].Name = "Tuổi";
            dgrip_Account1.Columns[6].Name = "Trạng Thái";
            dgrip_Account1.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrip_Account1.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }
        void Cach2_LoadData() //Chạy bằng SqlCommand
        {
            _conn = new SqlConnection(_sqlConnectionString);
            _conn.Open(); //Mở kết nối CDSDL
            _cmd = new SqlCommand("Select * from Accounts_ADO", _conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(_cmd); //Sd SqlDataAdapter hứng DL khi truy vấn

            //DataTable là con của DataSet và nó tương ứng 1 bảng trong CSDL bao gồm Row và Col
            //DataSet là tập hợp các bảng bên trong

            //Dùng DataTable
            DataTable tb = new DataTable();
            dataAdapter.Fill(tb); //Đổ dữ liệu vào Table
            dgrip_Account1.DataSource = tb;
            _conn.Close();
        }
        void Cach3_LoadData() //Không cần chạy SqlCommand
        {
            _conn = new SqlConnection(_sqlConnectionString);
            _conn.Open(); //Mở kết nối CDSDL
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Accounts_ADO", _conn);

            //Dùng DataTable
            DataTable tb = new DataTable();
            dataAdapter.Fill(tb); //Đổ dữ liệu vào Table
            dgrip_Account1.DataSource = tb;
            _conn.Close();
        }
        void Cach4_LoadData()
        {
            _conn = new SqlConnection(_sqlConnectionString);
            _conn.Open(); //Mở kết nối CDSDL
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from Accounts_ADO", _conn);

            //Dùng DataSet
            DataSet dt = new DataSet();
            dataAdapter.Fill(dt); //Đổ dữ liệu vào Table
            dgrip_Account1.DataSource = dt.Tables[0];
            _conn.Close();
        }

        void loadCbx_NamSinh()
        {
            foreach (var x in _serviceAccounts.getYearOfBirth())
            {
                cbo_NamSinh.Items.Add(x);
            }
            //Hiển thị giá trị cuối cùng của Combobox trừ đi 10
            cbo_NamSinh.SelectedIndex = _serviceAccounts.getYearOfBirth().Length - 10;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn muốn thêm tài khoản này không ?", "Xác nhận",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                _conn = new SqlConnection(_sqlConnectionString);
                _conn.Open();
                string query = @"INSERT INTO Accounts_ADO(Acc, Pass, Sex, YearofBirth, Status) 
                                 VALUES(@Acc, @Pass, @Sex, @YearofBirth, @Status)";
                _cmd = new SqlCommand(query, _conn);
                _cmd.CommandText = query;
                //_cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                _cmd.Parameters.AddWithValue("@Acc", txt_Acc.Text);
                _cmd.Parameters.AddWithValue("@Pass", txt_PassWork.Text);
                _cmd.Parameters.AddWithValue("@Sex", rbtnNam.Checked ? 1 : 0);
                _cmd.Parameters.AddWithValue("@YearofBirth", cbo_NamSinh.Text);
                _cmd.Parameters.AddWithValue("@Status", cbx_HoatDong.Checked);
                _cmd.ExecuteNonQuery();

                _conn.Close();
                Cach1_LoadData();
            }
        }

        private void btn_Repair_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn có sửa tài khoản này không ?", "Thông báo", 
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (cn == DialogResult.OK)
            {
                _conn = new SqlConnection(_sqlConnectionString);
                _conn.Open();
                string query = @"UPDATE Accounts_ADO SET Pass = @Pass, Sex = @Sex, YearofBirth = @YearofBirth, 
                                                         Status = @Status WHERE Acc = @Acc";
                _cmd = new SqlCommand(query, _conn);
                _cmd.CommandText = query;
                //_cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                _cmd.Parameters.AddWithValue("@Acc", txt_Acc.Text);
                _cmd.Parameters.AddWithValue("@Pass", txt_PassWork.Text);
                _cmd.Parameters.AddWithValue("@Sex", rbtnNam.Checked ? 1 : 0);
                _cmd.Parameters.AddWithValue("@YearofBirth", cbo_NamSinh.Text);
                _cmd.Parameters.AddWithValue("@Status", cbx_HoatDong.Checked);
                _cmd.ExecuteNonQuery();

                _conn.Close();
                Cach1_LoadData();
            }
        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            DialogResult dlr;
            dlr = MessageBox.Show("Bạn muốn xóa tài khoản này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                _conn = new SqlConnection(_sqlConnectionString);
                _conn.Open();
                string query = @"DELETE FROM Accounts_ADO WHERE Acc = '" + txt_Acc.Text + "'";
                _cmd = new SqlCommand(query, _conn);
                _cmd.CommandText = query; 
                _cmd.ExecuteNonQuery();

                _conn.Close();
                Cach1_LoadData();
            }
        }
        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataToGridByAcc(txtTimKiem.Text);
        }

        void LoadDataToGridByAcc(string acc)
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _serviceAccounts.getLstAccountsByAcc(acc);//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(Account);
            int slThuocTinh = type.GetProperties().Length;
            dgrip_Account1.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrip_Account1.Columns[0].Name = "Id";
            dgrip_Account1.Columns[1].Name = "Tài Khoản";
            dgrip_Account1.Columns[2].Name = "Mật Khẩu";
            dgrip_Account1.Columns[3].Name = "Giới Tính";
            dgrip_Account1.Columns[4].Name = "Năm Sinh";
            dgrip_Account1.Columns[5].Name = "Tuổi";
            dgrip_Account1.Columns[6].Name = "Trạng Thái";
            dgrip_Account1.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrip_Account1.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }

        private void dgrip_Account1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex; 
            if (rowIndex == _lstAccounts.Count) return; 
            var idAccount = dgrip_Account1.Rows[rowIndex].Cells[0].Value; 
            _account = _serviceAccounts.finAccount((Guid)idAccount);      

            txt_Acc.Text = _account.Acc;
            txt_PassWork.Text = _account.Pass;
            rbtnNam.Checked = _account.Sex == 1 ? true : false;
            rbtnNu.Checked = _account.Sex == 0 ? true : false;
            cbo_NamSinh.SelectedIndex = cbo_NamSinh.FindString(_account.YearofBirth.ToString());
            cbx_HoatDong.Checked = _account.Status ? true : false;
            cbx_KhongHoatDong.Checked = _account.Status == false ? true : false;
        }

        private void txt_PassWork_Validating(object sender, CancelEventArgs e)
        {
            DialogResult cn;
            if (txt_PassWork.Text.Length < 3)
            {
                e.Cancel = true;
                txt_PassWork.Focus();
                cn = MessageBox.Show("Mật khẩu phải trên 3 kí tự, Vui lòng nhập lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void txt_Acc_Validating(object sender, CancelEventArgs e)
        {
            DialogResult cn;
            if (Regex.Match(txt_Acc.Text, @"^[a-zA-Z]+$").Success)
            {
                e.Cancel = true;
                txt_Acc.Focus();
                cn = MessageBox.Show("Tài khoản phải có số, Vui lòng nhập lại!", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //private void cbo_NamSinh_Validating(object sender, CancelEventArgs e)
        //{
        //    DialogResult cn;
        //    if (Regex.IsMatch(cbo_NamSinh.Text, @"^\d+$").Equals(cbo_NamSinh.SelectedIndex))
        //    {
        //        e.Equals(cbo_NamSinh.SelectedItem);
        //        cbo_NamSinh.Focus();
        //        cn = MessageBox.Show("Mật khẩu chỉ được phép nhập số, Vui lòng nhập lại!", "Thông báo",
        //                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void _2_MainAccount_ADO_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", " Xác nhận",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit(); 
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", " Xác nhận",
                MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
