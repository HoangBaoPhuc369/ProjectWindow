﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPetDTO
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Category{ get; set; }

        public int Quanlity { get; set; }

        public double Price { get; set; }
    }
}