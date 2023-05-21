using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.Model
{
    [Table("Oders")] // Đặt tên bảng
    public class Oder
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(29)]
        public string Code { get; set; }
        public DateTime? DateCreate { get; set; }

        [ForeignKey("AccountId")] //Tạo tên cột khóa phụ
        public Account Account { get; set; }
    }
}
