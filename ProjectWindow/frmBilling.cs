using ShopPet.BusinessAccessLayer;
using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWindow
{
    public partial class frmBilling : Form
    {
        private readonly CustomerBAL _customerBAL;
        private readonly ProductBAL _productBAL;
        private readonly DetailsBAL _detailsBAL;
        public frmBilling()
        {
            InitializeComponent();
            _customerBAL = new CustomerBAL();
            _productBAL = new ProductBAL();
            _detailsBAL = new DetailsBAL();
        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            LoadListCustomer();
            LoadProduct();
            LoadDetails();
        }
        private void LoadListCustomer()
        {
            cbbCustomer.DisplayMember = "Name";
            cbbCustomer.ValueMember = "ID";
            List<CustomerDTO> ls = _customerBAL.GetCustomers();
            cbbCustomer.DataSource = ls;
        }

        private void LoadProduct()
        {
            List<ProductDTO> list = _productBAL.GetProducts();
            dgvProductList.DataSource = list;
            dgvProductList.ClearSelection();
        }
        private void LoadDetails()
        {
            List<DetailsDTO> list = _detailsBAL.GetDetails();
            dgvDetails.DataSource = list;
            dgvDetails.ClearSelection();
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductList.SelectedRows[0];

            txtProName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbbCustomer.SelectedIndex = -1;
            txtProName.Text = "";
            txtQuanlity.Text = "";
            txtPrice.Text = "";
            dgvProductList.ClearSelection();
        }

        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            string error;
            Detail details = new Detail();
            details.Price = double.Parse(txtPrice.Text);
            details.Product = txtProName.Text;
            details.Quanlity = int.Parse(txtQuanlity.Text);
            details.Total = details.Price*details.Quanlity;
            if (_detailsBAL.SaveDetails(details, out error))
            {
                MessageBox.Show("Save success!");
                LoadDetails();
                //Clear();
            }
            else
            {
                MessageBox.Show("Save fail! " + error);
            }
        }
    }
}
