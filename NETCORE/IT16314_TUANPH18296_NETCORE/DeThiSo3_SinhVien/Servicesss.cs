using DeThiSo3_SinhVien.Context;
using DeThiSo3_SinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DeThiSo3_SinhVien
{
    public class Servicesss
    {
        private List<SinhVien> _lstSinhViens;
        private List<Nganh> _lstNganhs;
        private DatabaseContext _dbContext;

        public Servicesss()
        {
            _lstSinhViens = new List<SinhVien>();
            _lstNganhs = new List<Nganh>();
            _dbContext = new DatabaseContext();
            GetlstDB();
        }
        public List<SinhVien> GetlstSinhvien()
        {
            return _lstSinhViens;
        }
        public List<Nganh> GetlistNganh()
        {
            return _lstNganhs;
        }
        public void GetlstDB()
        {
            _lstSinhViens = _dbContext.SinhViens.ToList();
            _lstNganhs = _dbContext.Nganhs.ToList();
        }
        public string AddSinhvien(SinhVien sv)
        {
            _dbContext.SinhViens.Add(sv);
            _dbContext.SaveChanges();
            return "Thêm thành công !";
        }
        public string UpdateSinhvien(SinhVien sv)
        {
            _dbContext.SinhViens.Update(sv);
            _dbContext.SaveChanges();
            return "Sửa thành công !";
        }
        public string RemoveSinhvien(SinhVien sv)
        {
            _dbContext.SinhViens.Remove(sv);
            _dbContext.SaveChanges();
            return "Xóa thành công !";
        }
        public string[] GetYearOfBirth()
        {
            string[] arrYear = new string[2021 - 1900];
            int temp = 1900;
            for (int i = 0; i < arrYear.Length; i++)
            {
                arrYear[i] = temp.ToString();
                temp++;
            }
            return arrYear;
        }
        public bool CheckString(string input)
        {
            if (input.All(char.IsDigit))
            {
                return true;
            }
            return false;
        }
        public bool CheckSo(string so)
        {
            if (Regex.IsMatch(so, @"[a-zA-Z]") == true)
            {
                return true;
            }
            return false;
        }
        public bool CheckNull(string nulllll)
        {
            if (string.IsNullOrWhiteSpace(nulllll))
            {
                return true;
            }
            return false;
        }
    }
}
