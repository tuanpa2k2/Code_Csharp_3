using BAI_1._2_CRUD_TaiKhoan.IServices;
using BAI_1._2_CRUD_TaiKhoan.Models;
using BAI_1._2_CRUD_TaiKhoan.Services;
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


namespace BAI_1._2_CRUD_TaiKhoan.Views
{
    public partial class frmMain : Form
    {
        //Khai báo các Service cần dùng
        private IServiceCounts _iserviceCounts;
        private IServiceFile _iServiceFile;
        private List<Account> _lstAccounts;
        private string _filePath;
        private Account _account;
        public frmMain()
        {
            InitializeComponent();
            _iServiceFile = new ServiceFile();
            _iserviceCounts = new ServiceAccount();
            LoadDataToGrid();
            loadCbxNamSinh();
            rbtnNam.Checked = true;
            cbx_KhongHoatDong.Checked = true;
        }
        
        void loadCbxNamSinh()
        {
            foreach (var x in _iserviceCounts.getYearOfBirth())
            {
                cbo_NamSinh.Items.Add(x);
            }
            //Hiển thị giá trị cuối cùng của Combobox trừ đi 10
            cbo_NamSinh.SelectedIndex = _iserviceCounts.getYearOfBirth().Length - 10;
        }
        void LoadDataToGrid()
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _iserviceCounts.getLstAccounts();//Lấy List Account
            Type type = typeof(Account); //Đếm số lượng thuộc tính có trong đối tượng
            int slThuocTinh = type.GetProperties().Length;
            dgrip_Table.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrip_Table.Columns[0].Name = "Id";
            dgrip_Table.Columns[1].Name = "Tài Khoản";
            dgrip_Table.Columns[2].Name = "Mật Khẩu";
            dgrip_Table.Columns[3].Name = "Giới Tính";
            dgrip_Table.Columns[4].Name = "Năm Sinh";
            dgrip_Table.Columns[5].Name = "Tuổi";
            dgrip_Table.Columns[6].Name = "Trạng Thái";
            dgrip_Table.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrip_Table.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }
        public void SenderDataFromLoginToMain(TextBox valueAcc, string path)
        {
            lbl_ChaoBan.Text = " Chào mừng bạn:  " + valueAcc.Text;
            _filePath = path;
            //Khi truyền dường dẫn từ form login lên main thì chúng ta đọc file và đổ dữ liệu vào Account Service
            _iserviceCounts.findDataTolistFromFile(_iServiceFile.openFile<Account>(path));
            LoadDataToGrid();
        }

        private void cbx_KhongHoatDong_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_KhongHoatDong.Checked)
            {
                cbx_HoatDong.Checked = false;
            }
        }

        private void lưuFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn có chắc lưu file không ?", "Xác nhận",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                MessageBox.Show(_iServiceFile.saveFile(_filePath, _lstAccounts), " Thông báo");
            }
        }

        private void dgrip_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //1. Lấy index row được bấm
            int rowIndex = e.RowIndex;
            if (rowIndex == _lstAccounts.Count) return;//Khi bấm vào dòng cuối của grid nằm ngoài index của
                                                       //List hiện tại thì sẽ ko làm gì
            //2. Lấy ra giá trị tại cột ID
            var idAccount = dgrip_Table.Rows[rowIndex].Cells[0].Value;
            //3. Gọi phương thức tìm kiếm bên Service
            _account = new Account();
            _account = _iserviceCounts.findAccount(Convert.ToInt32(idAccount));
            //4. Khi đối tượng đc tìm thấy thì sẽ fill data lên trên các Control
            txt_Acc.Text = _account.Acc;
            txt_PassWork.Text = _account.Pass;
            rbtnNam.Checked = _account.Sex == 1 ? true : false;
            rbtnNu.Checked = _account.Sex == 0 ? true : false;
            cbo_NamSinh.SelectedIndex = cbo_NamSinh.FindString(_account.YearofBirth.ToString());
            cbx_HoatDong.Checked = _account.Status ? true : false;
            cbx_KhongHoatDong.Checked = _account.Status == false ? true : false;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_PassWork.Text.Length >3)
            {
                DialogResult cn;
                cn = MessageBox.Show("Bạn muốn thêm tài khoản này không ?", "Xác nhận",
                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cn == DialogResult.Yes)
                {
                    _account = new Account();
                    _account.Id = _lstAccounts.Count;
                    _account.Acc = txt_Acc.Text;
                    _account.Pass = txt_PassWork.Text;
                    _account.Sex = rbtnNam.Checked ? 1 : 0;
                    _account.YearofBirth = Convert.ToInt32(cbo_NamSinh.SelectedItem);
                    _account.Status = cbx_HoatDong.Checked;
                    MessageBox.Show(_iserviceCounts.addAccount(_account), " Thông báo");
                    LoadDataToGrid();//Sau khi thêm mới phải load lại Grid
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu phải trên 3 kí tự, Vui lòng nhập lại !", " Thông báo");
                return;
            }
        }

        private void btn_Repair_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn muốn sửa tài khoản này không ?", "Xác nhận",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                _account.Acc = txt_Acc.Text;
                _account.Pass = txt_PassWork.Text;
                _account.Sex = rbtnNam.Checked ? 1 : 0;
                _account.YearofBirth = Convert.ToInt32(cbo_NamSinh.SelectedItem);
                _account.Status = cbx_HoatDong.Checked;
                MessageBox.Show(_iserviceCounts.editAccount(_account), " Thông báo");
                LoadDataToGrid();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn muốn xóa tài khoản này không ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cn == DialogResult.Yes)
            {
                MessageBox.Show(_iserviceCounts.removeAccount(_lstAccounts.Where(c => c.Acc == txt_Acc.Text).
                    Select(c => c.Id).FirstOrDefault()));
                LoadDataToGrid();
            }
        }

        private void txtTimKiem_KeyUp(object sender, KeyEventArgs e)
        {
            LoadDataToGridByAcc(txtTimKiem.Text);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cn;
            cn = MessageBox.Show("Bạn muốn thoát Form này không ?", "Xác nhận",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (cn == DialogResult.OK)
            {
                Application.Exit();
                return;
            }
            else
            {
                e.Cancel = true;
            }
        }
        void LoadDataToGridByAcc(string acc)
        {
            _lstAccounts = new List<Account>();//Khởi tạo mới List
            _lstAccounts = _iserviceCounts.getLstAccountsByAcc(acc);//Lấy List Account
            //Đếm số lượng thuộc tính có trong đối tượng
            Type type = typeof(Account);
            int slThuocTinh = type.GetProperties().Length;
            dgrip_Table.ColumnCount = slThuocTinh + 1;//Khởi tạo số lượng cột
            dgrip_Table.Columns[0].Name = "Id";
            dgrip_Table.Columns[1].Name = "Tài Khoản";
            dgrip_Table.Columns[2].Name = "Mật Khẩu";
            dgrip_Table.Columns[3].Name = "Giới Tính";
            dgrip_Table.Columns[4].Name = "Năm Sinh";
            dgrip_Table.Columns[5].Name = "Tuổi";
            dgrip_Table.Columns[6].Name = "Trạng Thái";
            dgrip_Table.Rows.Clear();
            foreach (var x in _lstAccounts)//Đổ dữ liệu vào datagrid
            {
                dgrip_Table.Rows.Add(x.Id, x.Acc, x.Pass, x.Sex == 1 ? "Nam" : "Nữ", x.YearofBirth,
                    DateTime.Now.Year - x.YearofBirth, x.Status ? "Hoạt động" : "Không Hoạt động");
            }
        }

    }
}
