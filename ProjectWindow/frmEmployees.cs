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
using ShopPetDTO;
using ShopPet.DataAccessLayer.Entities;

namespace ProjectWindow
{
    public partial class frmEmployees : Form
    {
        private readonly EmployeeBAL _employeeBAL;
        public frmEmployees()
        {
            InitializeComponent();
            _employeeBAL = new EmployeeBAL();
            this.Load += FrmEmployees_Load;
        }

        private void FrmEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }

        private void LoadEmployeeList() 
        {
            List<EmployeeDTO> listEmployee = _employeeBAL.GetEmployees();
            dgvListEmployee.DataSource = listEmployee;
            dgvListEmployee.ClearSelection();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string error;
            Employee employee = new Employee();
            employee.EmpName = txtEmpName.Text;
            employee.EmpAddr = txtEmpAddr.Text;
            employee.EmpPhone = txtEmpPhone.Text;
            employee.EmpPass = txtEmpPass.Text;
            employee.EmpDOB = EmpDOB.Value.Date;
            if (_employeeBAL.SaveEmployee(employee, out error))
            {
                MessageBox.Show("Save success!");
                LoadEmployeeList();
                Clear();
            }
            else
            {
                MessageBox.Show("Save fail! " + error);
            }
        }

        private void dgvListEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lấy row hiện tại
            DataGridViewRow row = dgvListEmployee.SelectedRows[0];

            // Chuyển giá trị lên form
            txtEmpName.Text = row.Cells[1].Value.ToString();
            txtEmpPass.Text = row.Cells[2].Value.ToString();
            txtEmpPhone.Text = row.Cells[3].Value.ToString();
            txtEmpAddr.Text = row.Cells[4].Value.ToString();
            EmpDOB.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string error;
            if (dgvListEmployee.SelectedRows.Count > 0)
            {
                // Lấy row hiện tại
                DataGridViewRow row = dgvListEmployee.SelectedRows[0];
                int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                // Xóa
                if (_employeeBAL.DeleteEmployee(ID, out error))
                {
                    MessageBox.Show("Delete success");
                    LoadEmployeeList();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Delete fail !!! " + error);
                }
            }
            else
            {
                MessageBox.Show("Choose a employee to delete!!!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string error;
            
            if (dgvListEmployee.SelectedRows.Count > 0)
            {
                if (txtEmpName.Text != "" && txtEmpPass.Text != "" && txtEmpPhone.Text != "" && txtEmpAddr.Text != "")
                {
                    DataGridViewRow row = dgvListEmployee.SelectedRows[0];
                    int ID = Convert.ToInt16(row.Cells[0].Value.ToString());
                    // Sửa
                    Employee employee = new Employee();
                    employee.EmpName = txtEmpName.Text;
                    employee.EmpAddr = txtEmpAddr.Text;
                    employee.EmpPhone = txtEmpPhone.Text;
                    employee.EmpPass = txtEmpPass.Text;
                    employee.EmpDOB = EmpDOB.Value.Date;
                    if (_employeeBAL.EditEmployee(ID, employee, out error))
                    {
                        MessageBox.Show("Edit success");
                        LoadEmployeeList();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Edit fail !!!" + error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Fill all information !!!");
                }
            }
            else
            {
                MessageBox.Show("Choose a Employee to Edit !!!");
            }
        }

        public void Clear()
        {
            txtEmpName.Text = "";
            txtEmpPass.Text = "";
            txtEmpAddr.Text = "";
            txtEmpPhone.Text = "";
        }
    }
}
