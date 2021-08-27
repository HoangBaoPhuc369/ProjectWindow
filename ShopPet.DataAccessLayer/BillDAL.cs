using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class BillDAL
    {
        public List<BillDTO> GetBill()
        {
            using (var dbcontext = new ShopPetModels())
            {
                var BillDTO = from b in dbcontext.Bills
                                  select new BillDTO()
                                  {
                                      ID = b.BillId,
                                      Customer = b.CusName,
                                      Employee = b.EmpName,
                                      Total = b.Total,
                                      Date = b.Billdate
                                  };
                return BillDTO.ToList();
            }
        }

        public bool BillUpdate(Bill bill, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Bills.Find(bill.BillId);
                    if (p == null)
                    {
                        error = "Bill not found!!!";
                        return false;
                    }
                    p.CusName = bill.CusName;
                    p.EmpName = bill.EmpName;
                    p.Total = bill.Total;
                    p.Billdate = bill.Billdate;
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
        public bool NewBill(Bill bill, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    dbcontext.Bills.Add(bill);
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
