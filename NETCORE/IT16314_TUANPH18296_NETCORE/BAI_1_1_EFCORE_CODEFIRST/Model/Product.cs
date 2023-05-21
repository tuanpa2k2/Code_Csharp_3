using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAI_1_1_EFCORE_CODEFIRST.Model
{
    [Table("Products")] //Đặt tên bảng
    public class Product
    {
        [Key] //Chỉ định dưới nó sẽ là khóa chính
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public bool? Status { get; set; }

    }
}
