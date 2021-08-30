using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Reporting
{
    public class BillInformation
    {
        public int BillID { get; set; }
        public string CusName { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public int Quanlity { get; set; }
        public double Price { get; set; }
    }
}
