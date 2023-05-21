using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAI_1._2_CRUD_TaiKhoan.IServices;
using BAI_1._2_CRUD_TaiKhoan.Models;
using BAI_1._2_CRUD_TaiKhoan.Services;

namespace BAI_1._2_CRUD_TaiKhoan.Views
{
    public partial class frmRegister : Form
    {
        //Khai báo các Service cần dùng
        private IServiceCounts _iServiceAccount;
        private IServiceFile _iServiceFiles;
        private List<Account> _lstAccounts;
        private string _filePath;
        private Account _account;
        public frmRegister()
        {
            InitializeComponent();
            //Khởi tạo
            _iServiceAccount = new ServiceAccount();
            _iServiceFiles = new ServiceFile();
            _lstAccounts = new List<Account>();
            rbtnNam.Checked = true;
            loadCbxNamSinh();//Load năm sinh khi chạy chương trình
        }

        void loadCbxNamSinh()
        {
            foreach (var x in _iServiceAccount.getYearOfBirth())
            {
                cbo_NamSinh.Items.Add(x);
            }
            //Hiển thị giá trị cuối cùng của Combobox trừ đi 10
            cbo_NamSinh.SelectedIndex = _iServiceAccount.getYearOfBirth().Length - 10;
        }

        public void SenderFilePathFromLogin(string duongDan)
        {
            _filePath = duongDan;
        }
        private void cbo_TaoTaiKhoan_Click(object sender, EventArgs e)
        {
            //Bước 1: Đọc file lên để lấy dữ liệu bên trong file data gán lại cho list toàn cục
            _lstAccounts = _iServiceFiles.openFile<Account>(_filePath);
            if (_lstAccounts == null)
            {
                _lstAccounts = new List<Account>();
            }
            //Bước 2: Khởi tạo và gán giá trị đối tường và thêm đối tượng vào cuối của danh sách đang có.
            //Nếu không đọc file lên sẽ bị ghi đè mất dữ liệu và luôn chỉ có đối tượng mới được lưu.
            _account = new Account();
            _account.Id = _lstAccounts.Count;
            _account.Acc = txxtAcc.Text;
            _account.Pass = txxtPass.Text;
            _account.Sex = rbtnNam.Checked ? 1 : 0;
            _account.YearofBirth = Convert.ToInt32(cbo_NamSinh.SelectedItem);
            _lstAccounts.Add(_account);
            //Bước 3: Lưu file
            MessageBox.Show(_iServiceFiles.saveFile(_filePath, _lstAccounts), "Thông báo");
            //Bước 4: Quay về bên form main
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

    }
}
