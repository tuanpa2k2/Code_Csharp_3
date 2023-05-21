using BAI_1._2_CRUD_TaiKhoan.IServices;
using BAI_1._2_CRUD_TaiKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1._2_CRUD_TaiKhoan.Services
{
    class ServiceAccount : IServiceCounts
    {
        private List<Account> _lstAccounts;
        public ServiceAccount()
        {
            _lstAccounts = new List<Account>();
        }
        public string addAccount(Account account)
        {
            if (account == null) return "==> Thêm thất bại ";
            _lstAccounts.Add(account);
            return "==> Thêm thành công !";
        }

        public string editAccount(Account account)
        {
            int index = _lstAccounts.FindIndex(c => c.Id == account.Id);
            if (index == -1)
            {
                return "==> Không tìm thấy đối tượng !";
            }
            _lstAccounts[index] = account;
            return "==> Sửa thành công !";
        }

        public Account findAccount(int id)
        {
            if (_lstAccounts.Where(c=> c.Id == id).FirstOrDefault() == null) return null;
            return _lstAccounts.FirstOrDefault(c => c.Id == id);
        }

        public void findDataTolistFromFile(List<Account> lstAccount)
        {
            _lstAccounts = lstAccount;
        }

        public List<Account> getLstAccounts()
        {
            return _lstAccounts;
        }

        public List<Account> getLstAccountsByAcc(string acc)
        {
            return _lstAccounts.Where(c => c.Acc.StartsWith(acc)).ToList();
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

        public string removeAccount(int id)
        {
            if (_lstAccounts.All(c => c.Id != id)) return "==> Xóa thất bại !";
            _lstAccounts.RemoveAt(_lstAccounts.FindIndex(c => c.Id == id));
            return "==> Xóa thành công !";
        }
    }
}
