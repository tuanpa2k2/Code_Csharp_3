using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.Model
{
    [Table("Accounts")] //Đặt tên bảng
    public class Account
    {
        [Key] //chỉ định nó sẽ là khóa chính
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Acc { get; set; }
        [StringLength(50)]
        public string Pass { get; set; }
        public int? Sex { get; set; }
        public int? YearofBirth { get; set; }
        public bool? Status { get; set; }


        [ForeignKey("RoleId")] // tạo tên cột của khóa phụ
        public Role Roles { get; set; }
    }
}
