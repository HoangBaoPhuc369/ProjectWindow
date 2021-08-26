﻿using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class ProductDAL
    {
        public List<ProductDTO> GetProduct()
        {
            using (var dbcontext = new ShopPetModels())
            {
                var ProductDTO = from b in dbcontext.Products
                                   select new ProductDTO()
                                   {
                                       ID = b.ProId,
                                       Name = b.ProName,
                                       Category = b.ProCate,
                                        Quanlity = b.ProQty,
                                         Price = b.ProPrice
                                   };
                return ProductDTO.ToList();
            }

        }

        public bool UpdateProduct(Product product, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var Update = dbcontext.Products.Find(product.ProId);
                    if (Update == null)
                    {
                        error = "Product not found !!!";
                        return false;
                    }
                    Update.ProName = product.ProName;
                    Update.ProCate = product.ProCate;
                    Update.ProQty = product.ProQty;
                    Update.ProPrice = product.ProPrice;
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

        public bool NewProduct(Product product, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    dbcontext.Products.Add(product);
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
        public bool DeleteProduct(Product product, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var Update = dbcontext.Products.Find(product.ProId);
                    if (Update == null)
                    {
                        error = "Product not found !!!";
                        return false;
                    }
                    dbcontext.Products.Remove(Update);
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