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
            //CountPets();
        }

        private void lblName_Click(object sender, EventArgs e)
        {
           
        }

        //public void CountPets()
        //{
        //    List<ProductDTO> listEmployee = _productBAL.GetNumOfPets("Dog");
        //    foreach (var item in listEmployee)
        //    {
        //        lblDog.Text = item.Quanlity.ToString();
        //    }
        //}
    }
}
