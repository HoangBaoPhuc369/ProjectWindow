using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class CustomerDAL
    {
        public List<CustomerDTO> GetCustomer()
        {
            using (var dbcontext = new ShopPetModels())
            {
                var CustomerDTO = from b in dbcontext.Customers
                                  select new CustomerDTO()
                                  {
                                      ID = b.CusId,
                                      Name = b.CusName,
                                      Phone = b.CusPhone,
                                      Address = b.CusAddr,
                                  };
                return CustomerDTO.ToList();
            }

        }

        public bool CustomerUpdate(Customer customer, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Customers.Find(customer.CusId);
                    if (p == null)
                    {
                        error = "Customer not found!!!";
                        return false;
                    }
                    p.CusName = customer.CusName;
                    p.CusPhone = customer.CusPhone;
                    p.CusAddr = customer.CusAddr;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public bool NewCustomer(Customer customer, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    dbcontext.Customers.Add(customer);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public bool RemoveCustomer(int id, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Customers.SingleOrDefault(x => x.CusId == id);
                    if (p == null)
                        return false;

                    dbcontext.Customers.Remove(p);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool EditCustomer(int id, Customer customer, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Customers.SingleOrDefault(x => x.CusId == id);
                    if (p == null)
                    {
                        error = "Customer not found!!!";
                        return false;
                    }
                    p.CusName = customer.CusName;
                    p.CusPhone = customer.CusPhone;
                    p.CusAddr = customer.CusAddr;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
