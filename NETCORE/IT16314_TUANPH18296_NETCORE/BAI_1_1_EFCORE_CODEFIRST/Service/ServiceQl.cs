using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAI_1_1_EFCORE_CODEFIRST.DB_Context_FPoly;
using BAI_1_1_EFCORE_CODEFIRST.Model;

namespace BAI_1_1_EFCORE_CODEFIRST.Service
{
    public class ServiceQl
    {
        private List<Account> _lstAccounts;
        private List<Oder> _lstOrders;
        private List<OrderDetail> _lstOrderDetails;
        private List<Product> _lstProducts;
        private List<Role> _lstRoles;
        private DbContext_Tuanpa _dbContext;
        public ServiceQl()
        {
            _dbContext = new DbContext_Tuanpa();
            _lstAccounts = new List<Account>();
            _lstOrders = new List<Oder>();
            _lstOrderDetails = new List<OrderDetail>();
            _lstProducts = new List<Product>();
            _lstRoles = new List<Role>();
            GetlstAccountsFromDB();
            GetlstProductsFromDB();
            GetlstRolesFromDB();
        }
        #region 1. Chức năng quản lý tài khoản
        public List<Role> GetlstRoles()
        {
            return _lstRoles;
        }
        public void GetlstRolesFromDB()
        {
            _lstRoles = _dbContext.Roles.ToList();
        }
        public List<Account> GetlstAccounts()
        {
            return _lstAccounts;
        }
        public void GetlstAccountsFromDB()
        {
            _lstAccounts = _dbContext.Accounts.ToList();
        }

        public string AddAccount(Account account)
        {
            _dbContext.Add(account);
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Thêm thành công";
        }
        public string UpdateAccount(Account account)
        {
            _dbContext.Update(account);
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Sửa thành công";
        }
        public string DeleteAccount(Guid id)
        {
            _dbContext.Remove(_lstAccounts.FirstOrDefault(c => c.Id == id));
            _dbContext.SaveChanges();
            GetlstAccountsFromDB();
            return "Xóa thành công";
        }
        //Tìm kiếm gần đúng
        public List<Account> GetlstAccounts(string acc)
        {
            return _lstAccounts.Where(c => c.Acc.ToLower().StartsWith(acc)).ToList();
        }
        #endregion

        #region 2. Quản lí sản phẩm
        public List<Product> GetlstProducts()
        {
            return _lstProducts;
        }
        public void GetlstProductsFromDB()
        {
            _lstProducts = _dbContext.Products.ToList();
        }

        public string AddProduct(Product pro)
        {
            _dbContext.Add(pro);
            _dbContext.SaveChanges();
            GetlstProductsFromDB();
            return "Thêm thành công";
        }
        public string UpdateProduct(Product pro)
        {
            _dbContext.Update(pro);
            _dbContext.SaveChanges();
            GetlstProductsFromDB();
            return "Sửa thành công";
        }
        public string DeleteProduct(Guid id)
        {
            _dbContext.Remove(_lstProducts.FirstOrDefault(c => c.Id == id));
            _dbContext.SaveChanges();
            GetlstProductsFromDB();
            return "Xóa thành công";
        }
        //Tìm kiếm gần đúng
        public List<Product> GetlstProducts(string acc)
        {
            return _lstProducts.Where(c => c.Name.ToLower().StartsWith(acc)).ToList();
        }
        #endregion

    }
}
