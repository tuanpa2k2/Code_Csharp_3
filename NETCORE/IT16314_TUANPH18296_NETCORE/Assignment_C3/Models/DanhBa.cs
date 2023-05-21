using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Assignment_C3.Models
{
    [Table("DanhBa")]
    public partial class DanhBa
    {
        public DanhBa()
        {
            Nguois = new HashSet<Nguoi>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Sdt1 { get; set; }
        [StringLength(50)]
        public string Sdt2 { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Ghichu { get; set; }

        [InverseProperty(nameof(Nguoi.Danhba))]
        public virtual ICollection<Nguoi> Nguois { get; set; }
    }
}
