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
    public class BillBAL
    {
        private readonly BillDAL _billDAL;

        public BillBAL()
        {
            _billDAL = new BillDAL();
        }

        public List<BillDTO> GetBills()
        {
            return _billDAL.GetBill();
        }

        public bool SaveBill(Bill bill, out string error)
        {
            try
            {
                if (bill.BillId > 0)
                {
                    if (!_billDAL.BillUpdate(bill, out error))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!_billDAL.NewBill(bill, out error))
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

    }
}
