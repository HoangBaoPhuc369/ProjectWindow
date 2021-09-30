using ShopPet.BusinessAccessLayer;
using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void LoadBill()
        {
            List<BillDTO> list = _billBAL.GetBills();
            dgvBill.DataSource = list;
            dgvBill.ClearSelection();
        }
        string Cate;
        private void dgvProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductList.SelectedRows[0];

            ID = int.Parse(row.Cells[0].Value.ToString());
            lblProName.Text = row.Cells[1].Value.ToString();
            lblCategory.Text = row.Cells[2].Value.ToString();
            Cate = row.Cells[2].Value.ToString();
            txtDescription.Text = row.Cells[3].Value.ToString();
            lblPrice.Text = row.Cells[5].Value.ToString();
            byte[] getImg;
            List<ImageDTO> list = _productBAL.GetImg(int.Parse(row.Cells[0].Value.ToString()));
            foreach (var item in list)
            {
                getImg = item.Img;
                pctBoxPet.Image = ByteToImg(getImg);
                break;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        double TotalPrice = 0;
        private void btnAddToBill_Click(object sender, EventArgs e)
        {
            if (cbbCustomer.SelectedIndex != -1 && lblPrice.Text != "" &&
                txtQuanlity.Text != "" && lblProName.Text != "")
            {
                //Lấy row hiện tại
                DataGridViewRow row = dgvProductList.SelectedRows[0];
                int check = int.Parse(row.Cells[4].Value.ToString());
                if (int.Parse(txtQuanlity.Text) <= check)
                {
                    double totalPrice = int.Parse(txtQuanlity.Text) * double.Parse(lblPrice.Text);
                    int selectedRow = dgvDetails.Rows.Add();
                    dgvDetails.Rows[selectedRow].Cells[0].Value = ID;
                    dgvDetails.Rows[selectedRow].Cells[1].Value = lblProName.Text;
                    dgvDetails.Rows[selectedRow].Cells[2].Value = Cate;
                    dgvDetails.Rows[selectedRow].Cells[3].Value = int.Parse(txtQuanlity.Text);
                    dgvDetails.Rows[selectedRow].Cells[4].Value = double.Parse(lblPrice.Text);
                    dgvDetails.Rows[selectedRow].Cells[5].Value = totalPrice;

                    double sum = 0;
                    for (int i = 0; i < dgvDetails.Rows.Count; i++)
                    {
                        sum += double.Parse(dgvDetails.Rows[i].Cells[5].Value.ToString());
                    }
                    lblTotal.Text = sum.ToString() + " $";
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
            //Pay the bills
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
                    //lưu chi tiết hóa đơn vô database
                    Detail dt = new Detail();
                    dt.IDBills = bill.BillId;
                    dt.IDProduct = int.Parse(dgvDetails.Rows[i].Cells[0].Value.ToString());
                    dt.Product = dgvDetails.Rows[i].Cells[1].Value.ToString();
                    dt.Category = dgvDetails.Rows[i].Cells[2].Value.ToString();
                    dt.Quanlity = int.Parse(dgvDetails.Rows[i].Cells[3].Value.ToString());
                    dt.Price = double.Parse(dgvDetails.Rows[i].Cells[4].Value.ToString());
                    dt.Total = double.Parse(dgvDetails.Rows[i].Cells[5].Value.ToString());               
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
                            checkQuanlity = int.Parse(item.Cells[4].Value.ToString());
                        }
                    }
                    //Lấy số lượng của sản phẩm trừ số lượng mua của khách hàng
                    product.ProQty = (int)(checkQuanlity - dt.Quanlity);
                    //Nếu số lượng vẫn còn thì lưu, không thì xóa ra khỏi danh mục sản phẩm
                    if (product.ProQty > 0)
                    {
                        if (_productBAL.SaveProductFromBill(product, out error))
                        {
                            LoadProduct();
                        }
                        else
                        {
                            MessageBox.Show(error);
                        }
                    }
                    else
                    {
                        if (_productBAL.DeleteProduct(product, out error))
                        {
                            LoadProduct();
                        }
                        else
                        {
                            MessageBox.Show(error);
                        }
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
            lblProName.Text = "";
            txtQuanlity.Text = "";
            lblPrice.Text = "";
            lblCategory.Text = "";
            txtDescription.Text = "";
            pctBoxPet.Image = null;
            dgvProductList.ClearSelection();
            dgvDetails.DataSource = null;
            dgvDetails.Rows.Clear();
            dgvDetails.Refresh();
            lblTotal.Text = "0 $";
        }

        public bool CheckValueOfTableDetails() 
        {
            foreach (DataGridViewRow rw in this.dgvDetails.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || 
                        String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
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
        private Image ByteToImg(byte[] byteString)
        {
            byte[] imgBytes = byteString;
            MemoryStream ms = new MemoryStream(imgBytes, 0, imgBytes.Length);
            ms.Write(imgBytes, 0, imgBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
