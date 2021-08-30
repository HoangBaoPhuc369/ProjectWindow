using ProjectWindow.Constance;
using Report;
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

namespace ProjectWindow
{
    public partial class frmMain : Form
    {
        public string user { get; set; }
        public frmMain()
        {
            InitializeComponent();
            this.pnlFormLoader.Controls.Clear();
            frmHome frmhome = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmhome.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmhome);
            frmhome.Show();
        }
        //Truyền dữ liệu qua main
        public frmMain(string user)
        {
            InitializeComponent();
            this.pnlFormLoader.Controls.Clear();
            frmHome frmhome = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmhome.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmhome);
            this.user = user;
            frmhome.Show();
        }
        private void bntHome_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmHome frmhome = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmhome.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmhome);
            frmhome.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmEmployees frmEmp = new frmEmployees() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmEmp.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmEmp);
            frmEmp.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmProduct frmPro = new frmProduct() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmPro.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmPro);
            frmPro.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmCustomers frmCus = new frmCustomers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmCus.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmCus);
            frmCus.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmBilling frmBill = new frmBilling(user) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmBill.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmBill);
            frmBill.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //đóng form main thì form login hiện lên
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Permission();
        }

        public void Permission()
        {
            if (GetValue.Permission == false)
            {
                btnEmployees.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            this.pnlFormLoader.Controls.Clear();
            frmReportInformation frmReport = new frmReportInformation();
            frmReport.Show();
        }
    }
}
