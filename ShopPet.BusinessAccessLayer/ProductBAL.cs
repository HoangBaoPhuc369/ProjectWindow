﻿using ShopPet.DataAccessLayer;
using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.BusinessAccessLayer
{
    public class ProductBAL
    {
        private readonly ProductDAL _productDAL;

        public ProductBAL()
        {
            _productDAL = new ProductDAL();
        }

        public List<ProductDTO> GetProducts()
        {
            return _productDAL.GetProduct();
        }

        public bool DeleteProduct(Product product, out string error)
        {

            try
            {

                if (!_productDAL.DeleteProduct(product, out error))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool SaveProduct(Product product, out string error)
        {
            try
            {
                //cập nhật
                if (product.ProId > 0)
                {
                    if (!_productDAL.UpdateProduct(product, out error))
                    {
                        return false;
                    }
                }
                //tạo mới
                else
                {
                    if (!_productDAL.NewProduct(product, out error))
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