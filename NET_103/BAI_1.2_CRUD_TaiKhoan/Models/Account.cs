using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1._2_CRUD_TaiKhoan.Models
{
    [Serializable]
    public class Account
    {
        public int Id { get; set; }
        public string Acc { get; set; } //Tài khoản
        public string Pass { get; set; } //Mật khẩu
        public int Sex { get; set; } // Giới tính
        public int YearofBirth { get; set; } //Giới tính
        public bool Status { get; set; } //True: Còn HĐ, False: không HĐ
    }
}
