using ShopPet.DataAccessLayer;
using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.BusinessAccessLayer
{
    public class CustomerBAL
    {
        private readonly CustomerDAL _customerDAL;

        public CustomerBAL()
        {
            _customerDAL = new CustomerDAL();
        }

        public List<CustomerDTO> GetCustomers()
        {
            return _customerDAL.GetCustomer();
        }

        public bool SaveCustomer(Customer customer, out string error)
        {
            error = string.Empty;
            if (customer.CusName == "" || customer.CusPhone == "" || customer.CusAddr == "" )
            {
                error = "\nPlease fill all information";
            }
            if (error != string.Empty)
            {
                return false;
            }
            try
            {
                //cập nhật
                if (customer.CusId > 0)
                {
                    if (!_customerDAL.CustomerUpdate(customer, out error))
                    {
                        return false;
                    }
                }
                //tạo mới
                else
                {
                    if (!_customerDAL.NewCustomer(customer, out error))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool DeleteCustomer(int ID, out string error)
        {
            return _customerDAL.RemoveCustomer(ID, out error);
        }

        public bool EditCustomer(int ID, Customer customer, out string error)
        {
            return _customerDAL.EditCustomer(ID, customer, out error);
        }
    }
}
