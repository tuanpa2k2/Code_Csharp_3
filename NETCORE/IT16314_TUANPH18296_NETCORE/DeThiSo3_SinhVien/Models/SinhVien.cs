using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DeThiSo3_SinhVien.Models
{
    [Table("SinhVien")]
    [Index(nameof(MaSv), Name = "UQ__SinhVien__2725081BEAE0628D", IsUnique = true)]
    public partial class SinhVien
    {
        [Key]
        public int Id { get; set; }
        [Column("MaSV")]
        [StringLength(50)]
        public string MaSv { get; set; }
        [Column("TenSV")]
        [StringLength(50)]
        public string TenSv { get; set; }
        [StringLength(100)]
        public string NamSinh { get; set; }
        public bool? TrangThai { get; set; }
        public int? IdNganh { get; set; }

        [ForeignKey(nameof(IdNganh))]
        [InverseProperty(nameof(Nganh.SinhViens))]
        public virtual Nganh IdNganhNavigation { get; set; }
    }
}
