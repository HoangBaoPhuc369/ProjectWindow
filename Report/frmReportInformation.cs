using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Report.DataAccessLayer;
using Report.Reporting;

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
                string QuerySql = "select b.BillId, CusName, Product, Category, Quanlity, Price " +
                    "from Details d, Bill b " +
                    "where d.IDBills = b.BillId";
                List<BillInformation> list = dbContext.Database.SqlQuery<BillInformation>
                    (QuerySql).ToList();

                if (txtIDBills.Text != "")
                {
                    list = list.Where(b => b.BillID == int.Parse(txtIDBills.Text)).ToList();
                    //list = list.Where(b => b.CusName.ToLower() == txtIDBills.Text.ToLower()).ToList();
                }
                this.rpvInformation.LocalReport.ReportPath = "ReportBills.rdlc";
                var reportDataSource = new ReportDataSource("BillsInformationDataset", list);
                this.rpvInformation.LocalReport.DataSources.Clear(); //clear
                this.rpvInformation.LocalReport.DataSources.Add(reportDataSource);
                this.rpvInformation.RefreshReport();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            ShowPriceListTable();
        }
    }
}
