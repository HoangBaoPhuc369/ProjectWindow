
namespace Report
{
    partial class frmReportInformation
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
            this.rpvInformation = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn1 = new System.Windows.Forms.Button();
            this.txtIDBills = new Guna.UI.WinForms.GunaTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpvInformation
            // 
            this.rpvInformation.Location = new System.Drawing.Point(1, 158);
            this.rpvInformation.Name = "rpvInformation";
            this.rpvInformation.ServerReport.BearerToken = null;
            this.rpvInformation.Size = new System.Drawing.Size(799, 294);
            this.rpvInformation.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btn1);
            this.panel1.Controls.Add(this.txtIDBills);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(214, 13);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 132);
            this.panel1.TabIndex = 1;
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(221, 80);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(75, 23);
            this.btn1.TabIndex = 5;
            this.btn1.Text = "View report";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // txtIDBills
            // 
            this.txtIDBills.BaseColor = System.Drawing.Color.White;
            this.txtIDBills.BorderColor = System.Drawing.Color.Silver;
            this.txtIDBills.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDBills.FocusedBaseColor = System.Drawing.Color.White;
            this.txtIDBills.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtIDBills.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtIDBills.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDBills.Location = new System.Drawing.Point(138, 44);
            this.txtIDBills.Name = "txtIDBills";
            this.txtIDBills.PasswordChar = '\0';
            this.txtIDBills.SelectedText = "";
            this.txtIDBills.Size = new System.Drawing.Size(160, 30);
            this.txtIDBills.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(134, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bill ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmReportInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rpvInformation);
            this.Name = "frmReportInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmReportInformation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvInformation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox txtIDBills;
        private System.Windows.Forms.Button btn1;
    }
}

