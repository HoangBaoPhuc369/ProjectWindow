using ShopPet.DataAccessLayer;
using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.BusinessAccessLayer
{
    public class EmployeeBAL
    {
        private readonly EmployeeDAL _employeeDAL;

        public EmployeeBAL()
        {
            _employeeDAL = new EmployeeDAL();
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return _employeeDAL.GetEmployee();
        }

        public bool SaveEmployee(Employee employee, out string error)
        {
            error = string.Empty;
            if (employee.EmpName == "" || employee.EmpPhone == "" || employee.EmpPass == "" || employee.EmpAddr == "")
            {
                error = "\nPlease fill all information";
            }
            if (error != string.Empty)
            {
                return false;
            }
            try
            {
                //cập nhật
                if (employee.EmpID > 0)
                {
                    if (!_employeeDAL.EmployeeUpdate(employee, out error))
                    {
                        return false;
                    }
                }
                //tạo mới
                else
                {
                    if (!_employeeDAL.NewEmployee(employee, out error))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        public bool DeleteEmployee(int empID, out string error)
        {
            return _employeeDAL.RemoveEmployee(empID, out error);
        }

        public bool EditEmployee(int empID, Employee employee, out string error)
        {
            return _employeeDAL.EditEmployee(empID, employee, out error);
        }
    }
}
