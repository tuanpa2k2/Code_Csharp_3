using BAI_1._2_CRUD_TaiKhoan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI_1._2_CRUD_TaiKhoan.IServices
{
    public interface IServiceCounts
    {
        //1. theem
        string addAccount(Account account);
        //2. sua
        string editAccount(Account account);
        //3. xoa
        string removeAccount(int id);
        //4. tim kiem tuyet doi
        Account findAccount(int id);
        //5. phuong thuc lay dsach
        List<Account> getLstAccounts();
        //6. loc danh sach gan dung
        List<Account> getLstAccountsByAcc(string acc);
        //7. Fill data vao list doi tuong khi doc len
        void findDataTolistFromFile(List<Account> lstAccount);
        //8. lay dsach nam sinh
        string[] getYearOfBirth();
    }
}
