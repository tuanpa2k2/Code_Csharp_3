using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DeThiSo1_TaiKhoan_1.Models
{
    [Table("TaiKhoan")]
    [Index(nameof(TenTk), Name = "UQ__TaiKhoan__4CF9E77765A276C0", IsUnique = true)]
    public partial class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        [Column("TenTK")]
        [StringLength(50)]
        public string TenTk { get; set; }
        [StringLength(50)]
        public string MatKhau { get; set; }
        public int? GioiTinh { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdChucVu { get; set; }

        [ForeignKey(nameof(IdChucVu))]
        [InverseProperty(nameof(LoaiTaiKhoan.TaiKhoans))]
        public virtual LoaiTaiKhoan IdChucVuNavigation { get; set; }
    }
}
