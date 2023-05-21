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
    public partial class frmForgotPassword : Form
    {
        //Khai báo các Service cần dùng
        private IServiceCounts _iserviceCounts;
        private IServiceFile _iserviceFile;
        private List<Account> _lstAccount;
        private string _filePath;
        public frmForgotPassword()
        {
            InitializeComponent();
            _iserviceCounts = new ServiceAccount();
            _iserviceFile = new ServiceFile();
            _lstAccount = new List<Account>();
            rbtnNam.Checked = true;
            loadCbxNamSinh();//Load năm sinh khi chạy chương trình
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
        public void SenderFilePathFromForGotPass(string duongDan)
        {
            _filePath = duongDan;
        }

        private void btn_TaoTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            if (txxt_Pass_moi.Text.Length >= 3)
            {
                foreach (var x in _lstAccount.Where
                    (c => c.Acc == txxt_Acc.Text && c.Sex == Convert.ToInt32(rbtnNam.Checked ? 1 : 0)))
                {
                    x.Pass = txxt_Pass_moi.Text;
                    MessageBox.Show(_iserviceFile.saveFile(_filePath, _lstAccount), " Thông báo");
                    this.Hide();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                    return;
                }
                cn = MessageBox.Show("Không tìm thấy tài khoản, Vui lòng nhập lại !", " Thông báo", 
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Không tìm thấy tài khoản, Vui lòng nhập lại !", " Thông báo");
            }
            else
            {
                cn = MessageBox.Show("Mật khẩu phải trên 3 kí tự, Vui lòng nhập lại!", " Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Mật khẩu phải trên 3 kí tự, Vui lòng nhập lại !", " Thông báo");
                return;
            }
        }

        private void btn_OpenData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _filePath = dlg.FileName;//Tên đường dẫn tuyệt đối của file khi mở file data
                lbl_path.Text = _filePath; //Show đường dẫn file
                _lstAccount = _iserviceFile.openFile<Account>(_filePath);//Đọc file lên và đổ giá trị trị đọc vào List ở form này
                _iserviceCounts.findDataTolistFromFile(_lstAccount);//Gán List đối tượng đã đọc của Account vào bên Service
            }
        }

    }
}
