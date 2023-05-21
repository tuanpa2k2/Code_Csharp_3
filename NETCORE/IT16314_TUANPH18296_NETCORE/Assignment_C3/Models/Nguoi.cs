using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Assignment_C3.Models
{
    [Table("Nguoi")]
    public partial class Nguoi
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ho { get; set; }
        [StringLength(50)]
        public string Tendem { get; set; }
        [StringLength(50)]
        public string Ten { get; set; }
        [StringLength(50)]
        public string Namsinh { get; set; }
        public int? Gioitinh { get; set; }
        [Column("DanhbaID")]
        public int? DanhbaId { get; set; }

        [ForeignKey(nameof(DanhbaId))]
        [InverseProperty(nameof(DanhBa.Nguois))]
        public virtual DanhBa Danhba { get; set; }
    }
}
