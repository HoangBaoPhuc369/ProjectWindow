using ShopPet.DataAccessLayer.Entities;
using ShopPetDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopPet.DataAccessLayer
{
    public class EmployeeDAL
    {
        public List<EmployeeDTO> GetEmployee()
        {
            using (var dbcontext = new ShopPetModels())
            {
                var EmployeeDTO = from b in dbcontext.Employees
                                  select new EmployeeDTO()
                                  {
                                      ID = b.EmpID,
                                      Name = b.EmpName,
                                      UserName = b.EmpUser,
                                      PassWord = b.EmpPass,
                                      Permission = b.Permission,
                                      Phone = b.EmpPhone,
                                      Address = b.EmpAddr,
                                      DateOfBirth = (DateTime)b.EmpDOB
                                  };
                return EmployeeDTO.ToList();
            }

        }

        public bool EmployeeUpdate(Employee employee, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var EmployeeUpdate = dbcontext.Employees.Find(employee.EmpID);
                    if (EmployeeUpdate == null)
                    {
                        error = "Employee not found!!!";
                        return false;
                    }
                    EmployeeUpdate.EmpName = employee.EmpName;
                    EmployeeUpdate.EmpUser = employee.EmpUser;
                    EmployeeUpdate.EmpPass = employee.EmpPass;
                    EmployeeUpdate.Permission = employee.Permission;
                    EmployeeUpdate.EmpPhone = employee.EmpPhone;
                    EmployeeUpdate.EmpAddr = employee.EmpAddr;
                    EmployeeUpdate.EmpDOB = employee.EmpDOB;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool NewEmployee(Employee employee, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    dbcontext.Employees.Add(employee);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
        public bool RemoveEmployee(int id, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Employees.SingleOrDefault(x => x.EmpID == id);
                    if (p == null)
                        return false;

                    dbcontext.Employees.Remove(p);
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        public bool EditEmployee(int id, Employee employee, out string error)
        {
            error = string.Empty;
            try
            {
                using (var dbcontext = new ShopPetModels())
                {
                    var p = dbcontext.Employees.SingleOrDefault(x => x.EmpID == id);
                    if (p == null)
                    {
                        error = "Employee not found!!!";
                        return false;
                    }
                    p.EmpName = employee.EmpName;
                    p.EmpUser = employee.EmpUser;
                    p.EmpPass = employee.EmpPass;
                    p.Permission = employee.Permission;
                    p.EmpPhone = employee.EmpPhone;
                    p.EmpAddr = employee.EmpAddr;
                    p.EmpDOB = employee.EmpDOB;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
