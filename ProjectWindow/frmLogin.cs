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
using ShopPet.DataAccessLayer.Entities;
using ProjectWindow.Constance;
using ShopPetDTO;

namespace ProjectWindow
{
    public partial class frmLogin : Form
    {
        private readonly AccountBAL _accountBAL;
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

        string empName;
        public void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill all information!");
                return;
            }

            string error;
            if (_accountBAL.CheckLogin(username, password, out error) || _accountBAL.CheckEmployeeLogin(username, password, out error))
            {
                MessageBox.Show("Login success!");
                List<EmployeeDTO> listEmployee = _accountBAL.GetEmployeeName(username, password);
                foreach (var item in listEmployee)
                {
                    empName = item.Name;
                }
                //Kiểm tra quyền hạn
                if (_accountBAL.CheckPermission(username, password, out error))
                {
                    MessageBox.Show("you've login with ADMIN permission");
                    GetValue.Permission = true;
                }
                else
                {
                    MessageBox.Show("you've login with USER permission");
                    GetValue.Permission = false;
                }
                GetEmployeeName.Name = empName;
                //Mở form main thì ẩn form login đi
                frmMain frmMain = new frmMain(empName);
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
            Application.Exit();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e) {}
    }
}
