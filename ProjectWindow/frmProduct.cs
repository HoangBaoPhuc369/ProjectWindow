using ProjectWindow.Constance;
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
            //CheckNumOfPet();
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
            if (txtName.Text != "" && cbbCategory.SelectedIndex != -1 && txtQuanlity.Text != "" 
                && txtPrice.Text != "" && txtDescription.Text != "" && pctBoxPet.Image != null)
            {
                string error;
                Product product = new Product();
                product.ProName = txtName.Text;
                product.ProCate = cbbCategory.Text;
                product.ProDes = txtDescription.Text;
                product.ProImg = ImageToByteArray(pctBoxPet.Image);
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
            if (dgvProduct.SelectedRows.Count > 0)
            {
                // Lấy row hiện tại
                DataGridViewRow row = dgvProduct.SelectedRows[0];
                int Id = Convert.ToInt16(row.Cells[0].Value.ToString());
                if (Id == 0)
                {
                    MessageBox.Show("Please choose a Product to edit!!!");
                    return;
                }
                string error;
                Product product = new Product();
                product.ProId = Id;
                product.ProName = txtName.Text;
                product.ProCate = cbbCategory.Text;
                product.ProDes = txtDescription.Text;
                product.ProImg = ImageToByteArray(pctBoxPet.Image);
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
            else
            {
                MessageBox.Show("Choose a product to edit!!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error;
            if (dgvProduct.SelectedRows.Count > 0)
            {
                // Lấy row hiện tại
                DataGridViewRow row = dgvProduct.SelectedRows[0];
                int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                // Xóa
                if (_productBAL.DeleteEmployeeByID(ID, out error))
                {
                    MessageBox.Show("Delete success");
                    LoadProduct();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Delete fail !!! " + error);
                }
            }
            else
            {
                MessageBox.Show("Choose a product to delete!!!");
            }
        }

        public void Clear()
        {
            txtName.Text = "";
            txtQuanlity.Text = "";
            cbbCategory.SelectedIndex = -1;
            txtDescription.Text = "";
            pctBoxPet.Image = null;
            txtQuanlity.Text = "";
            txtPrice.Text = "";
            dgvProduct.ClearSelection();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProduct.SelectedRows[0];

            ID = int.Parse(row.Cells[0].Value.ToString());
            txtName.Text = row.Cells[1].Value.ToString();
            cbbCategory.Text = row.Cells[2].Value.ToString();
            txtDescription.Text = row.Cells[3].Value.ToString();
            txtQuanlity.Text = row.Cells[4].Value.ToString();
            txtPrice.Text = row.Cells[5].Value.ToString();
            byte[] getImg;
            List<ImageDTO> list = _productBAL.GetImg(int.Parse(row.Cells[0].Value.ToString()));
            foreach (var item in list)
            {
                getImg = item.Img;              
                pctBoxPet.Image = ByteToImg(getImg);
                break;
            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            Clear();
        }
  
        private void btnChooseIMG_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jbg)|*.jpg| PNG files(*.png)|*.png| All files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pctBoxPet.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
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
