using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Report.DataAccessLayer;

namespace Report
{
    public partial class frmReportInformation : Form
    {
        public frmReportInformation()
        {
            InitializeComponent();
        }

        private void frmReportInformation_Load(object sender, EventArgs e)
        {

            ShowPriceListTable();
        }

        private void ShowPriceListTable()
        {
            using (var dbContext = new ShopPetDbContext())
            {
                string QuerySql = "select d.IDProduct, Product, Category, Price " +
                    "from Details d, Bill b " +
                    "where d.IDBills = b.BillId";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
