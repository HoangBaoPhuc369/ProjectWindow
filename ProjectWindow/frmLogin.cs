using ProjectWindow.Helpers;
using ShopPet.BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace ProjectWindow
{
    public partial class frmLogin : Form
    {
        private readonly AccountBAL _accountBAL;
        //public event LoginSucessDelegate loginSucess;
        public frmLogin()
        {
            InitializeComponent();
            _accountBAL = new AccountBAL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
        }

        private bool ValidateInput(object sender)
        {
            GunaTextBox txtInput = (GunaTextBox)sender;
            if (txtInput.Text == "")
            {
                errorProvider1.SetError(txtInput, "Vui lòng nhập thông tin!");
                return false;
            }
            errorProvider1.SetError(txtInput, "");
            return true;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            ValidateInput(sender);
        }
        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            ValidateInput(sender);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill all information!");
                return;
            }
            string error;
            if (_accountBAL.CheckLogin(username, password, out error))
            {
                MessageBox.Show("Login success!");
                //Mở form main thì ẩn form login đi
                frmMain frmMain = new frmMain();
                this.Visible = false;
                frmMain.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Login fail! \n" + error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
