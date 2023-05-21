using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAI_1_1_EFCORE_CODEFIRST.Model
{
    [Table("OrderDetails")] //Đặt tên bảng
    public class OrderDetail
    {
            [Key] //Chỉ định dưới nó sẽ là khóa chính
            public Guid Id { get; set; }

            [ForeignKey("ProductId")] //Tạo tên cột khóa phụ
            public Product Product { get; set; }

            [ForeignKey("OrderId")]
            public Oder Oder { get; set; }
            public int? Quantity { get; set; }
            public double? Price { get; set; }
    }
}
