using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class DetailsDAL
    {
        public List<DetailsDTO> GetDetails()
        {
            using (var dbcontext = new ShopPetModels())
            {
                var DetailsDTO = from b in dbcontext.Details
                                 select new DetailsDTO()
                                 {
                                     ID = b.ID,
                                     Product = b.Product,
                                     Quanlity = b.Quanlity,
                                     Price = b.Price,
                                     Total = b.Total
                                 };
                return DetailsDTO.ToList();
            }

        }
        public bool DetailsUpdate(Detail details, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Details.Find(details.ID);
                    if (p == null)
                    {
                        error = "Detail not found!!!";
                        return false;
                    }
                    p.Product = details.Product;
                    p.Quanlity = details.Quanlity;
                    p.Price = details.Price;
                    p.Total = details.Total;
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
        public bool NewDetails(Detail detail, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    dbcontext.Details.Add(detail);
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
