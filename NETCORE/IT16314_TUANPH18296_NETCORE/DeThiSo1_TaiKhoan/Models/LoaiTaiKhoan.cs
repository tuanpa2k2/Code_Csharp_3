using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DeThiSo1_TaiKhoan.Models
{
    [Table("LoaiTaiKhoan")]
    [Index(nameof(MaTk), Name = "UQ__LoaiTaiK__27250071FD37AC1C", IsUnique = true)]
    public partial class LoaiTaiKhoan
    {
        public LoaiTaiKhoan()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        [Key]
        public int Id { get; set; }
        [Column("MaTK")]
        [StringLength(100)]
        public string MaTk { get; set; }
        [Column("TenTK")]
        [StringLength(100)]
        public string TenTk { get; set; }

        [InverseProperty(nameof(TaiKhoan.IdChucVuNavigation))]
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
