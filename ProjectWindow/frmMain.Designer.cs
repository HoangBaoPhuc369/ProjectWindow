
namespace ProjectWindow
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaElipse2 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.bntHome = new Guna.UI.WinForms.GunaButton();
            this.btnEmployees = new Guna.UI.WinForms.GunaButton();
            this.btnProduct = new Guna.UI.WinForms.GunaButton();
            this.btnCustomers = new Guna.UI.WinForms.GunaButton();
            this.btnBilling = new Guna.UI.WinForms.GunaButton();
            this.btnLogOut = new Guna.UI.WinForms.GunaButton();
            this.gunaElipse3 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.btnReport = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaElipse2
            // 
            this.gunaElipse2.Radius = 30;
            this.gunaElipse2.TargetControl = this.pnlFormLoader;
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Location = new System.Drawing.Point(199, 9);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(885, 583);
            this.pnlFormLoader.TabIndex = 7;
            // 
            // bntHome
            // 
            this.bntHome.AnimationHoverSpeed = 0.07F;
            this.bntHome.AnimationSpeed = 0.03F;
            this.bntHome.BackColor = System.Drawing.Color.Transparent;
            this.bntHome.BaseColor = System.Drawing.Color.Transparent;
            this.bntHome.BorderColor = System.Drawing.Color.Black;
            this.bntHome.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bntHome.FocusedColor = System.Drawing.Color.Empty;
            this.bntHome.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntHome.ForeColor = System.Drawing.Color.White;
            this.bntHome.Image = ((System.Drawing.Image)(resources.GetObject("bntHome.Image")));
            this.bntHome.ImageSize = new System.Drawing.Size(20, 20);
            this.bntHome.Location = new System.Drawing.Point(2, 150);
            this.bntHome.Name = "bntHome";
            this.bntHome.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bntHome.OnHoverBorderColor = System.Drawing.Color.Black;
            this.bntHome.OnHoverForeColor = System.Drawing.Color.White;
            this.bntHome.OnHoverImage = null;
            this.bntHome.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bntHome.Size = new System.Drawing.Size(195, 42);
            this.bntHome.TabIndex = 2;
            this.bntHome.Text = "Home";
            this.bntHome.Click += new System.EventHandler(this.bntHome_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.AnimationHoverSpeed = 0.07F;
            this.btnEmployees.AnimationSpeed = 0.03F;
            this.btnEmployees.BackColor = System.Drawing.Color.Transparent;
            this.btnEmployees.BaseColor = System.Drawing.Color.Transparent;
            this.btnEmployees.BorderColor = System.Drawing.Color.Black;
            this.btnEmployees.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEmployees.FocusedColor = System.Drawing.Color.Empty;
            this.btnEmployees.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployees.Image")));
            this.btnEmployees.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEmployees.Location = new System.Drawing.Point(2, 198);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEmployees.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEmployees.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEmployees.OnHoverImage = null;
            this.btnEmployees.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEmployees.Size = new System.Drawing.Size(195, 42);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.AnimationHoverSpeed = 0.07F;
            this.btnProduct.AnimationSpeed = 0.03F;
            this.btnProduct.BackColor = System.Drawing.Color.Transparent;
            this.btnProduct.BaseColor = System.Drawing.Color.Transparent;
            this.btnProduct.BorderColor = System.Drawing.Color.Black;
            this.btnProduct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnProduct.FocusedColor = System.Drawing.Color.Empty;
            this.btnProduct.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnProduct.Image")));
            this.btnProduct.ImageSize = new System.Drawing.Size(20, 20);
            this.btnProduct.Location = new System.Drawing.Point(2, 246);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnProduct.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnProduct.OnHoverForeColor = System.Drawing.Color.White;
            this.btnProduct.OnHoverImage = null;
            this.btnProduct.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnProduct.Size = new System.Drawing.Size(195, 42);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Text = "Product";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.AnimationHoverSpeed = 0.07F;
            this.btnCustomers.AnimationSpeed = 0.03F;
            this.btnCustomers.BackColor = System.Drawing.Color.Transparent;
            this.btnCustomers.BaseColor = System.Drawing.Color.Transparent;
            this.btnCustomers.BorderColor = System.Drawing.Color.Black;
            this.btnCustomers.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCustomers.FocusedColor = System.Drawing.Color.Empty;
            this.btnCustomers.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.Image")));
            this.btnCustomers.ImageSize = new System.Drawing.Size(20, 20);
            this.btnCustomers.Location = new System.Drawing.Point(2, 294);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCustomers.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnCustomers.OnHoverForeColor = System.Drawing.Color.White;
            this.btnCustomers.OnHoverImage = null;
            this.btnCustomers.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCustomers.Size = new System.Drawing.Size(195, 42);
            this.btnCustomers.TabIndex = 3;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.AnimationHoverSpeed = 0.07F;
            this.btnBilling.AnimationSpeed = 0.03F;
            this.btnBilling.BackColor = System.Drawing.Color.Transparent;
            this.btnBilling.BaseColor = System.Drawing.Color.Transparent;
            this.btnBilling.BorderColor = System.Drawing.Color.Black;
            this.btnBilling.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnBilling.FocusedColor = System.Drawing.Color.Empty;
            this.btnBilling.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Image = ((System.Drawing.Image)(resources.GetObject("btnBilling.Image")));
            this.btnBilling.ImageSize = new System.Drawing.Size(20, 20);
            this.btnBilling.Location = new System.Drawing.Point(2, 342);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnBilling.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnBilling.OnHoverForeColor = System.Drawing.Color.White;
            this.btnBilling.OnHoverImage = null;
            this.btnBilling.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBilling.Size = new System.Drawing.Size(195, 42);
            this.btnBilling.TabIndex = 5;
            this.btnBilling.Text = "Billing";
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.AnimationHoverSpeed = 0.07F;
            this.btnLogOut.AnimationSpeed = 0.03F;
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BaseColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderColor = System.Drawing.Color.Black;
            this.btnLogOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogOut.FocusedColor = System.Drawing.Color.Empty;
            this.btnLogOut.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLogOut.Location = new System.Drawing.Point(2, 550);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnLogOut.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLogOut.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLogOut.OnHoverImage = null;
            this.btnLogOut.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLogOut.Size = new System.Drawing.Size(195, 42);
            this.btnLogOut.TabIndex = 6;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // gunaElipse3
            // 
            this.gunaElipse3.Radius = 15;
            this.gunaElipse3.TargetControl = this;
            // 
            // btnReport
            // 
            this.btnReport.AnimationHoverSpeed = 0.07F;
            this.btnReport.AnimationSpeed = 0.03F;
            this.btnReport.BackColor = System.Drawing.Color.Transparent;
            this.btnReport.BaseColor = System.Drawing.Color.Transparent;
            this.btnReport.BorderColor = System.Drawing.Color.Black;
            this.btnReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReport.FocusedColor = System.Drawing.Color.Empty;
            this.btnReport.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageSize = new System.Drawing.Size(20, 20);
            this.btnReport.Location = new System.Drawing.Point(2, 390);
            this.btnReport.Name = "btnReport";
            this.btnReport.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnReport.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnReport.OnHoverForeColor = System.Drawing.Color.White;
            this.btnReport.OnHoverImage = null;
            this.btnReport.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnReport.Size = new System.Drawing.Size(195, 42);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1096, 607);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.bntHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaElipse gunaElipse2;
        private Guna.UI.WinForms.GunaButton btnLogOut;
        private Guna.UI.WinForms.GunaButton btnBilling;
        private Guna.UI.WinForms.GunaButton btnCustomers;
        private Guna.UI.WinForms.GunaButton btnProduct;
        private Guna.UI.WinForms.GunaButton btnEmployees;
        private Guna.UI.WinForms.GunaButton bntHome;
        private Guna.UI.WinForms.GunaElipse gunaElipse3;
        private System.Windows.Forms.Panel pnlFormLoader;
        private Guna.UI.WinForms.GunaButton btnReport;
    }
}