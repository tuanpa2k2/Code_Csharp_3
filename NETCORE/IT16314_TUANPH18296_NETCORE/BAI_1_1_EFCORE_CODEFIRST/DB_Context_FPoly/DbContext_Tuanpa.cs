using BAI_1_1_EFCORE_CODEFIRST.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1_1_EFCORE_CODEFIRST.DB_Context_FPoly
{
    public class DbContext_Tuanpa:DbContext
    {
        //1. Ghi đề 1 phương thức OncConFiguring của lớp cha
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-V4BEME9\\SQLEXPRESS01;Initial Catalog=IT16314_DBCODEFIRST;Persist Security Info=True;User ID=tuanpa03;Password=2002");
            }
        }
        //2. Khai báo bảng
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Oder> Oders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
