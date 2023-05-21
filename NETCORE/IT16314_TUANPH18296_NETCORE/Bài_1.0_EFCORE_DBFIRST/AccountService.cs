using Bài_1._0_EFCORE_DBFIRST.Context;
using Bài_1._0_EFCORE_DBFIRST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_1._0_EFCORE_DBFIRST
{
    class AccountService
    {
        private List<AccountsAdo> _lstAccountsAdo;
        private DatabaseContext _dbContext;
        public AccountService()
        {
            _lstAccountsAdo = new List<AccountsAdo>();
            _dbContext = new DatabaseContext();
            GetLstAccountsDB();
        }
        public List<AccountsAdo> GetLstAccountsAdo()
        {
            return _lstAccountsAdo;
        }
        private void GetLstAccountsDB()
        {
            _lstAccountsAdo = _dbContext.AccountsAdos.ToList(); // Lấy dữ liệu trên bảng AccountsAdo ở DB
        }

        /// <summary>
        /// Phương thức thêm đối tượng vào trong CSDL
        /// </summary>
        /// <param name="acc">Truyền vào đối tượng Account</param>
        /// <returns>Thành công thì trả về True</returns>
        public bool Insert(AccountsAdo acc)
        {
            _dbContext.AccountsAdos.Add(acc);
            _dbContext.SaveChanges();
            GetLstAccountsAdo();
            return true;
        }
        public bool Update(AccountsAdo acc)
        {
            _dbContext.AccountsAdos.Update(acc);
            _dbContext.SaveChanges();
            GetLstAccountsAdo();
            return true;
        }
        public bool Delete(Guid id)
        {
            var temp = _lstAccountsAdo.Where(c => c.Id == id).FirstOrDefault(); //FirstOrDefault : lấy ra cả đới tượng
            _dbContext.AccountsAdos.Remove(temp);
            _dbContext.SaveChanges();
            GetLstAccountsAdo();
            return true;
        }
        public List<AccountsAdo> GetLstAccountsAdoByAcc(string acc)
        {
            return _lstAccountsAdo.Where(c=>c.Acc.StartsWith(acc)).ToList();
        }
        public AccountsAdo finAccount(Guid id)
        {
            if (_lstAccountsAdo.Where(c => c.Id == id).FirstOrDefault() == null) return null;
            return _lstAccountsAdo.FirstOrDefault(c => c.Id == id);
        }
        public string[] getYearOfBirth()
        {
            string[] arrYears = new string[2021 - 1900];
            int temp = 1900;
            for (int i = 0; i < arrYears.Length; i++)
            {
                arrYears[i] = temp.ToString();
                temp++;
            }
            return arrYears;
        }

    }
}
