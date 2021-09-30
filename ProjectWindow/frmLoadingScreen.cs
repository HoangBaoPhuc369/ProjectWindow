using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProjectWindow
{
    public partial class frmLoadingScreen : Form
    {
        public frmLoadingScreen()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void frmLoadingScreen_Load(object sender, EventArgs e)
        {
            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
        }
        int startProgress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startProgress += 2;
            gunaProgressBar1.Value = startProgress;
            lblPercentTarget.Text = startProgress + "%";
            if (gunaProgressBar1.Value == 100)
            {
                gunaProgressBar1.Value = 0;
                ShowFormLogin();
                //Thread thread = new Thread(new ThreadStart(ShowFormLogin)); //Tạo luồng mới
                //thread.Start(); //Khởi chạy luồng
                this.Hide(); //đóng Form hiện tại
                timer1.Stop();
            }
        }

        private void ShowFormLogin()
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }
    }
}
