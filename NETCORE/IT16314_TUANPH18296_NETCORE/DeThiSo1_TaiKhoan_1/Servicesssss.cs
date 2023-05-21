using DeThiSo1_TaiKhoan_1.Models;
using DeThiSo1_TaiKhoan_1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeThiSo1_TaiKhoan_1
{
    public class Servicesssss
    {
        private List<TaiKhoan> _lstTaikhoans;
        private List<LoaiTaiKhoan> _lstLoaiTaikhoans;
        private DatabaseContext _dbContext;
        public Servicesssss()
        {
            _lstTaikhoans = new List<TaiKhoan>();
            _lstLoaiTaikhoans = new List<LoaiTaiKhoan>();
            _dbContext = new DatabaseContext();
            GetFromDB();
        }
        public List<TaiKhoan> GetlstTaikhoan()
        {
            return _lstTaikhoans;
        }
        public List<LoaiTaiKhoan> GetlstLoaitaikhoan()
        {
            return _lstLoaiTaikhoans;
        }
        public void GetFromDB()
        {
            _lstTaikhoans = _dbContext.TaiKhoans.ToList();
            _lstLoaiTaikhoans = _dbContext.LoaiTaiKhoans.ToList();
        }

        public string AddTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Add(tk);
            _dbContext.SaveChanges();
            return "Add thanh cong !";
        }
        public string UpdateTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Update(tk);
            _dbContext.SaveChanges();
            return "Update thanh cong !";
        }
        public string RemoveTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Remove(tk);
            _dbContext.SaveChanges();
            return "Remove thanh cong !";
        }
        public List<TaiKhoan> GetlstByName(string namee)
        {
            return _lstTaikhoans.Where(c =>c.TenTk.StartsWith(namee)).ToList();
        }
    }
}
