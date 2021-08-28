using ShopPet.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class AccountDAL
    {
        public bool CheckLogin(string username, string password, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    return dbcontext.Accounts.Any(tk => tk.Username == username && tk.Password == password);
                }
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }

        public bool CheckEmployeeLogin(string username, string password, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    return dbcontext.Employees.Any(tk => tk.EmpUser == username && tk.EmpPass == password);
                }
            }
            catch (Exception exception)
            {
                error = exception.Message;
                return false;
            }
        }
    }
}
