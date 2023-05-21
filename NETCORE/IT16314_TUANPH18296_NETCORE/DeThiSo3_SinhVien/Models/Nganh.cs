using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DeThiSo3_SinhVien.Models
{
    [Table("Nganh")]
    [Index(nameof(MaNganh), Name = "UQ__Nganh__A2CEF50C5AFD6187", IsUnique = true)]
    public partial class Nganh
    {
        public Nganh()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string MaNganh { get; set; }
        [StringLength(100)]
        public string TenNganh { get; set; }

        [InverseProperty(nameof(SinhVien.IdNganhNavigation))]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
