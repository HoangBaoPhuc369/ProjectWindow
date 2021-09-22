using ProjectWindow.Constance;
using ShopPet.BusinessAccessLayer;
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
    public partial class frmHome : Form
    {
        private readonly ProductBAL _productBAL;
        public string name { get; set; }
        public frmHome()
        {
            InitializeComponent();
            _productBAL = new ProductBAL();
        }
        public frmHome(string name)
        {
            InitializeComponent();
            this.name = name;
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblName.Text = GetEmployeeName.Name;
            TotalDogs();
            TotalCats();
            TotalHamster();
            TotalFoods();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
           
        }

        public void TotalDogs()
        {
            List<ProductDTO> list = _productBAL.GetNumOfPets("Dog");
            foreach (var item in list)
            {
                lblDog.Text = item.Quanlity.ToString();
            }
        }

        public void TotalCats()
        {
            List<ProductDTO> list = _productBAL.GetNumOfPets("Cat");
            foreach (var item in list)
            {
                lblCat.Text = item.Quanlity.ToString();
            }
        }

        public void TotalHamster()
        {
            List<ProductDTO> list = _productBAL.GetNumOfPets("Hamster");
            foreach (var item in list)
            {
                lblHamster.Text = item.Quanlity.ToString();
            }
        }

        public void TotalFoods()
        {
            List<ProductDTO> list = _productBAL.GetNumOfPets("Food");
            foreach (var item in list)
            {
                lblFoods.Text = item.Quanlity.ToString();
            }
        }
    }
}
