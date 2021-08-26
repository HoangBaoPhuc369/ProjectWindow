﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPetDTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}