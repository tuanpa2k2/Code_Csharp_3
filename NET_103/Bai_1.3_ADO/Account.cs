using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_1._3_ADO
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Acc { get; set; } //Tài khoản
        public string Pass { get; set; } //Mật khẩu
        public int Sex { get; set; } // Giới tính
        public int YearofBirth { get; set; } //Giới tính
        public bool Status { get; set; } //True: Còn HĐ, False: không HĐ
    }
}
