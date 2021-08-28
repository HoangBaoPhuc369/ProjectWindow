﻿using ShopPet.BusinessAccessLayer;
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
        private readonly BillBAL _billBAL;
        int ID;
        public string User { get; set; }
        public frmBilling()
        {
            InitializeComponent();
            _customerBAL = new CustomerBAL();
            _productBAL = new ProductBAL();
            _detailsBAL = new DetailsBAL();
            _billBAL = new BillBAL();
        }

        public frmBilling(string user)
        {
            InitializeComponent();
            _customerBAL = new CustomerBAL();
            _productBAL = new ProductBAL();
            _detailsBAL = new DetailsBAL();
            _billBAL = new BillBAL();
            this.User = user;
        }
        private void frmBilling_Load(object sender, EventArgs e)
        {
            LoadListCustomer();
            LoadProduct();
            LoadDetails();
            LoadBill();
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
            //    List<DetailsDTO> list = _detailsBAL.GetDetails();
            //    dgvDetails.DataSource = list;
            //    dgvDetails.ClearSelection();

            //table.Columns.Add("Product", typeof(string));
            //table.Columns.Add("Quanlity", typeof(int));
            //table.Columns.Add("Price", typeof(double));
            //table.Columns.Add("Total", typeof(double));
            //dgvDetails.DataSource = table;
        }

        private void LoadBill()
        {
            List<BillDTO> list = _billBAL.GetBills();
            dgvBill.DataSource = list;
            dgvBill.ClearSelection();
        }

        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductList.SelectedRows[0];

            ID = int.Parse(row.Cells[0].Value.ToString());
            txtProName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[4].Value.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        double TotalPrice = 0;
        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            //string error;
            //double sum = 0;
            //Detail details = new Detail();
            //details.Price = double.Parse(txtPrice.Text);
            //details.Product = txtProName.Text;
            //details.Quanlity = int.Parse(txtQuanlity.Text);
            //details.Total = details.Price*details.Quanlity;
            //sum += details.Total;
            //if (_detailsBAL.SaveDetails(details, out error))
            //{
            //    MessageBox.Show("Save success!");
            //    LoadDetails();
            //    //Clear();
            //}
            //else
            //{
            //    MessageBox.Show("Save fail! " + error);
            //}         
            if (cbbCustomer.SelectedIndex != -1 && txtPrice.Text != "" && txtQuanlity.Text != "" && txtProName.Text != "")
            {
                DataGridViewRow row = dgvProductList.SelectedRows[0];
                int check = int.Parse(row.Cells[3].Value.ToString());
                if (int.Parse(txtQuanlity.Text) < check)
                {
                    double totalPrice = int.Parse(txtQuanlity.Text) * double.Parse(txtPrice.Text);
                    int selectedRow = dgvDetails.Rows.Add();
                    dgvDetails.Rows[selectedRow].Cells[0].Value = ID;
                    dgvDetails.Rows[selectedRow].Cells[1].Value = txtProName.Text;
                    dgvDetails.Rows[selectedRow].Cells[2].Value = int.Parse(txtQuanlity.Text);
                    dgvDetails.Rows[selectedRow].Cells[3].Value = double.Parse(txtPrice.Text);
                    dgvDetails.Rows[selectedRow].Cells[4].Value = totalPrice;

                    double sum = 0;
                    for (int i = 0; i < dgvDetails.Rows.Count; i++)
                    {
                        sum += double.Parse(dgvDetails.Rows[i].Cells[4].Value.ToString());
                    }
                    lblTotal.Text = sum.ToString() + " VND";
                    TotalPrice = sum;
                }
                else
                {
                    MessageBox.Show("Out of Quanlity !!!");
                }
            }
            else
            {
                MessageBox.Show("Missing information !!!");
            }
        }

        public void txtPrint_Click(object sender, EventArgs e)
        {
            if (CheckValueOfTableDetails())
            {
                string error;
                Bill bill = new Bill();
                bill.CusName = cbbCustomer.Text;
                bill.EmpName = User;
                bill.Billdate = DateTime.Now;
                bill.Total = double.Parse(TotalPrice.ToString());
                if (_billBAL.SaveBill(bill, out error))
                {
                    MessageBox.Show("Pay success!");
                    LoadBill();
                }
                else
                {
                    MessageBox.Show("Pay fail! " + error);
                }

                for (int i = 0; i < dgvDetails.Rows.Count; i++)
                {
                    Detail dt = new Detail();
                    dt.Product = dgvDetails.Rows[i].Cells[1].Value.ToString();
                    dt.Quanlity = int.Parse(dgvDetails.Rows[i].Cells[2].Value.ToString());
                    dt.Price = double.Parse(dgvDetails.Rows[i].Cells[3].Value.ToString());
                    dt.Total = double.Parse(dgvDetails.Rows[i].Cells[4].Value.ToString());
                    //lưu chi tiết hóa đơn vô database               
                    if (_detailsBAL.SaveDetails(dt, out error))
                    {

                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                    int checkQuanlity = 0;
                    Product product = new Product();
                    product.ProId = int.Parse(dgvDetails.Rows[i].Cells[0].Value.ToString());
                    //tìm số lượng sản phẩn dựa trên ID
                    foreach (DataGridViewRow item in dgvProductList.Rows)
                    {
                        if (int.Parse(item.Cells[0].Value.ToString()) == product.ProId)
                        {
                            checkQuanlity = int.Parse(item.Cells[3].Value.ToString());
                        }
                    }
                    product.ProQty = checkQuanlity - dt.Quanlity;
                    if (_productBAL.SaveProductFromBill(product, out error))
                    {
                        LoadProduct();
                    }
                    else
                    {
                        MessageBox.Show(error);
                    }
                }
                Clear();
                MessageBox.Show("Bill saved");
            }
            else
            {
                MessageBox.Show("Bills is empty");
            }
            
        }

        public void Clear()
        {
            cbbCustomer.SelectedIndex = -1;
            txtProName.Text = "";
            txtQuanlity.Text = "";
            txtPrice.Text = "";
            dgvProductList.ClearSelection();
            dgvDetails.DataSource = null;
            dgvDetails.Rows.Clear();
            dgvDetails.Refresh();
            lblTotal.Text = "0 VND";
        }

        public bool CheckValueOfTableDetails() 
        {
            foreach (DataGridViewRow rw in this.dgvDetails.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {

                    }
                    else
                    {
                        return true;
                    }
                }             
            }
            return false;
        }
    }
}
