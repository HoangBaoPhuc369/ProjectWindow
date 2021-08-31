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
    public partial class frmCustomers : Form
    {
        private readonly CustomerBAL _customerBAL;
        public frmCustomers()
        {
            InitializeComponent();
            _customerBAL = new CustomerBAL();
            this.Load += FrmCustomers_Load;
        }

        private void FrmCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
            Permission();
        }
        public void Permission()
        {
            if (GetValue.Permission == false)
            {
                btnDelete.Enabled = false;
            }
        }
        private void LoadCustomerList()
        {
            List<CustomerDTO> listCustomer = _customerBAL.GetCustomers();
            dgvListCustomer.DataSource = listCustomer;
            dgvListCustomer.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string error;
            Customer customer = new Customer();
            customer.CusName = txtCusName.Text;
            customer.CusPhone = txtCusPhone.Text;
            customer.CusAddr = txtCusAddr.Text;
            if (_customerBAL.SaveCustomer(customer, out error))
            {
                MessageBox.Show("Save success!");
                LoadCustomerList();
                Clear();
            }
            else
            {
                MessageBox.Show("Save fail! " + error);
            }
        }     

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error;
            if (dgvListCustomer.SelectedRows.Count > 0)
            {
                // Lấy row hiện tại
                DataGridViewRow row = dgvListCustomer.SelectedRows[0];
                int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                // Xóa
                if (_customerBAL.DeleteCustomer(ID, out error))
                {
                    MessageBox.Show("Delete success");
                    LoadCustomerList();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Delete fail !!! " + error);
                }
            }
            else
            {
                MessageBox.Show("Choose a customer to delete!!!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string error;

            if (dgvListCustomer.SelectedRows.Count > 0)
            {
                if (txtCusName.Text != "" && txtCusPhone.Text != "" && txtCusAddr.Text != "")
                {
                    DataGridViewRow row = dgvListCustomer.SelectedRows[0];
                    int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                    // Sửa
                    Customer customer = new Customer();
                    customer.CusName = txtCusName.Text;
                    customer.CusPhone = txtCusPhone.Text;
                    customer.CusAddr = txtCusAddr.Text;
                    if (_customerBAL.EditCustomer(ID, customer, out error))
                    {
                        MessageBox.Show("Edit success");
                        LoadCustomerList();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Edit fail !!!" + error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill all information !!!");
                }
            }
            else
            {
                MessageBox.Show("Choose a Customer to Edit !!!");
            }
        }

        public void Clear()
        {
            txtCusName.Text = "";
            txtCusAddr.Text = "";
            txtCusPhone.Text = "";
            dgvListCustomer.ClearSelection();
        }

        private void dgvListCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lấy row hiện tại
            DataGridViewRow row = dgvListCustomer.SelectedRows[0];

            // Chuyển giá trị lên form
            txtCusName.Text = row.Cells[1].Value.ToString();
            txtCusPhone.Text = row.Cells[2].Value.ToString();
            txtCusAddr.Text = row.Cells[3].Value.ToString();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
