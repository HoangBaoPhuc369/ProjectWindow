using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPetDTO
{
    public class BillDTO
    {
        public int ID { get; set; }
        public string Customer { get; set; }

        public string Employee { get; set; }

        public double Total { get; set; }

        public DateTime Date { get; set; }

    }
}
