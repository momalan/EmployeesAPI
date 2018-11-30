using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;

namespace Employees.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        List<Employee> PostEmployee(Employee e);
        List<Employee> DeleteEmployee(int id);
        Employee GetEmpById(int id);
        Employee UpdateEMploye(int id, Employee egm);
        List<Employee> ActOrInactive(bool x);
        List<Employee> EmployeeDepartment(int d);
        List<Employee> EmployeeDepartmentActive(int d, bool x);
    }
}
