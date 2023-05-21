using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using BAI_1._2_CRUD_TaiKhoan.IServices;
using BAI_1._2_CRUD_TaiKhoan.Models;
using BAI_1._2_CRUD_TaiKhoan.Services;

namespace BAI_1._2_CRUD_TaiKhoan.Views
{
    public partial class frmLogin : Form
    {
        //Khai báo các Service cần dùng
        private IServiceCounts _iserviceCounts;
        private IServiceFile _iserviceFile;
        private List<Account> _lstAccount;
        private string _filePath;
        public frmLogin()
        {
            InitializeComponent();
            _iserviceCounts = new ServiceAccount();
            _iserviceFile = new ServiceFile();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            DialogResult cn;
            foreach (var x in _lstAccount.Where(c => c.Acc == txxt_Acc.Text && c.Pass == txxt_Pass.Text))
            {
                if (x.Status == true)
                {
                    if (_lstAccount.Any(c => c.Acc == txxt_Acc.Text && c.Pass == txxt_Pass.Text))
                    {
                        frmMain frmMain = new frmMain();//Khởi tạo lớp đối tượng
                        frmMain.SenderDataFromLoginToMain(txxt_Acc, _filePath);//Gọi phương thức bên main để truyền dữ liệu
                        this.Hide();//Ẩn form hiện tại đi
                        cn = MessageBox.Show("Đăng nhập thành công !", " Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmMain.Show();//Hiển thị form Main lên
                        return;
                    }
                    else
                    {
                        cn = MessageBox.Show("Vui lòng kiểm trả lại Acc & Pass", " Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MessageBox.Show("Vui lòng kiểm trả lại Acc & Pass", " Thông báo");
                        return;
                    }
                }
                else
                {
                    cn = MessageBox.Show("Tài khoản không hoạt động và không thể đăng nhập !", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Tài khoản không hoạt động và không thể đăng nhập !", "Thông báo");
                    return;
                }
            }
        }

        private void btn_OpenData_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _filePath = dlg.FileName;//Tên đường dẫn tuyệt đối của file khi mở file data
                lbl_path.Text = _filePath;
                //Đọc file lên và đổ giá trị trị đọc vào List ở form này
                _lstAccount = _iserviceFile.openFile<Account>(_filePath);
                //Gán List đối tượng đã đọc từ file vào bên Service
                _iserviceCounts.findDataTolistFromFile(_lstAccount);
            }
        }

        private void lbl_DangKi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();//Ẩn form hiện tại
            frmRegister frmRegister = new frmRegister();
            frmRegister.SenderFilePathFromLogin(_filePath);//Truyền đường dẫn từ login sang form đăng ký thông qua tham số của phương thức
            frmRegister.Show();
        }

        private void lbl_QuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();//Ẩn form hiện tại
            frmForgotPassword frm = new frmForgotPassword();
            frm.SenderFilePathFromForGotPass(_filePath);
            frm.Show();
        }

    }
}
