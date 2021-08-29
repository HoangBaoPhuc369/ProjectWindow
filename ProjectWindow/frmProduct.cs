using ProjectWindow.Constance;
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
    public partial class frmProduct : Form
    {
        private readonly ProductBAL _productBAL;
        int ID;
        public frmProduct()
        {
            InitializeComponent();
            _productBAL = new ProductBAL();
            this.Load += FrmProduct_Load; ;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
            Permission();
        }
        public void Permission()
        {
            if (GetValue.Permission == false)
            {
                btnDelete.Enabled = false;
            }
        }
        private void LoadProduct()
        {
            List<ProductDTO> list = _productBAL.GetProducts();
            dgvProduct.DataSource = list;
            dgvProduct.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && cbbCategory.SelectedIndex != -1 && txtQuanlity.Text != "" && txtPrice.Text != "")
            {
                string error;
                Product product = new Product();
                product.ProName = txtName.Text;
                product.ProCate = cbbCategory.Text;
                product.ProQty = int.Parse(txtQuanlity.Text);
                product.ProPrice = double.Parse(txtPrice.Text);

                if (_productBAL.SaveProduct(product, out error))
                {
                    MessageBox.Show("Save success");
                    LoadProduct();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Save fail !!! \n" + error);
                }
            }
            else
            {
                MessageBox.Show("Please Fill all information !!!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Please choose a Product to edit!!!");
                return;
            }
            string error;
            Product product = new Product();
            product.ProId = ID;
            product.ProName = txtName.Text;
            product.ProCate = cbbCategory.Text;
            product.ProQty = int.Parse(txtQuanlity.Text);
            product.ProPrice = double.Parse(txtPrice.Text);
            if (_productBAL.SaveProduct(product, out error))
            {
                MessageBox.Show("Edited");
                LoadProduct();
                Clear();
            }
            else
            {
                MessageBox.Show("Edit fail !!! \n" + error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("Please choose a Product to delete!!!");
                return;
            }
            string error;
            Product product = new Product();
            product.ProId = ID;
            product.ProName = txtName.Text;
            product.ProCate = cbbCategory.Text;
            product.ProQty = int.Parse(txtQuanlity.Text);
            product.ProPrice = double.Parse(txtPrice.Text);
            if (_productBAL.DeleteProduct(product, out error))
            {
                MessageBox.Show("Delete success!");
                LoadProduct();
                Clear();
            }
            else
            {
                MessageBox.Show("Delete fail !!! \n" + error);
            }
        }

        public void Clear()
        {
            txtName.Text = "";
            txtQuanlity.Text = "";
            cbbCategory.SelectedIndex = -1;
            txtQuanlity.Text = "";
            txtPrice.Text = "";
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProduct.SelectedRows[0];

            ID = int.Parse(row.Cells[0].Value.ToString());
            txtName.Text = row.Cells[1].Value.ToString();
            cbbCategory.Text = row.Cells[2].Value.ToString();
            txtQuanlity.Text = row.Cells[3].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
        }
    }
}
