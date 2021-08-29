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
    public class DetailsBAL
    {
        private readonly DetailsDAL _detailsDAL;

        public DetailsBAL()
        {
            _detailsDAL = new DetailsDAL();
        }

        //public List<DetailsDTO> GetDetails()
        //{
        //    return _detailsDAL.GetDetails();
        //}

        public bool SaveDetails(Detail details, out string error)
        {
            try
            {
                //cập nhật
                if (details.ID > 0)
                {
                    if (!_detailsDAL.DetailsUpdate(details, out error))
                    {
                        return false;
                    }
                }
                //tạo mới
                else
                {
                    if (!_detailsDAL.NewDetails(details, out error))
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
