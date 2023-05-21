using DeThiSo1_TaiKhoan.Context;
using DeThiSo1_TaiKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeThiSo1_TaiKhoan
{
    public class Servicess
    {
        private List<TaiKhoan> _lstTaiKhoans;
        private List<LoaiTaiKhoan> _lstLoaiTKs;
        private DatabaseContext _dbContext;
        public Servicess()
        {
            _lstTaiKhoans = new List<TaiKhoan>();
            _lstLoaiTKs = new List<LoaiTaiKhoan>();
            _dbContext = new DatabaseContext();
            GetlstFromDB();
        }
        public List<TaiKhoan> GetlstTaiKhoan()
        {
            return _lstTaiKhoans;
        }
        public List<LoaiTaiKhoan> GetlstLoaiTK()
        {
            return _lstLoaiTKs;
        }
        public void GetlstFromDB()
        {
            _lstTaiKhoans = _dbContext.TaiKhoans.ToList();
            _lstLoaiTKs = _dbContext.LoaiTaiKhoans.ToList();
        }

        public string AddTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Add(tk);
            _dbContext.SaveChanges();
            return "Thêm thành công";
        }
        public string UpdateTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Update(tk);
            _dbContext.SaveChanges();
            return "Sửa thành công";
        }
        public string RemoveTaiKhoan(TaiKhoan tk)
        {
            _dbContext.TaiKhoans.Remove(tk);
            _dbContext.SaveChanges();
            return "Xóa thành công";
        }

    }
}
