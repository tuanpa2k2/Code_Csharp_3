using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment_C3.Models;
using Assignment_C3.Context;

namespace Assignment_C3.Service
{
    public class ServiceDanhba
    {
        private List<Nguoi> _lstNguois;
        private List<DanhBa> _lstDanhBas;
        private DatabaseContext _dbContext;
        public ServiceDanhba()
        {
            _lstNguois = new List<Nguoi>();
            _lstDanhBas = new List<DanhBa>();
            _dbContext = new DatabaseContext();
            GetlistFromDB();
        }
        public void GetlistFromDB()
        {
            _lstNguois = _dbContext.Nguois.ToList();
            _lstDanhBas = _dbContext.DanhBas.ToList();
        }
        public List<Nguoi> GetlstNguoi()
        {
            return _lstNguois;
        }
        public List<DanhBa> GetlstDanhba()
        {
            return _lstDanhBas;
        }
        public string AddNguoi(Nguoi ng, DanhBa db)
        {
            _lstNguois.Add(ng);
            _lstDanhBas.Add(db);
            _dbContext.Nguois.Add(ng);
            _dbContext.DanhBas.Add(db);
            _dbContext.SaveChanges();
            return "ADD thanh cong";
        }
        public string UpdateNguoi(Nguoi ng)
        {
            _dbContext.Nguois.Update(ng);
            _dbContext.SaveChanges();
            return "UPDATE thanh cong";
        }
        public string RemoveNguoi(Nguoi ng)
        {
            _dbContext.Nguois.Remove(ng);
            _dbContext.SaveChanges();
            return "REMOVE thanh cong";
        }
        public string[] GetYearOfBirth()
        {
            string[] arrYaer = new string[2021 - 1990];
            int temp = 1990;
            for (int i = 0; i < arrYaer.Length; i++)
            {
                arrYaer[i] = temp.ToString();
                temp++;
            }
            return arrYaer;
        }
    }
}
