using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Model;

namespace Employees.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<Employee> ActOrInactive(bool x)
        {
            throw new NotImplementedException();
        }

        public List<Employee> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> EmployeeDepartment(int d)
        {
            throw new NotImplementedException();
        }

        public List<Employee> EmployeeDepartmentActive(int d, bool x)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmpById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Employee> PostEmployee(Employee e)
        {
            throw new NotImplementedException();
        }

        public Employee UpdateEMploye(int id, Employee egm)
        {
            throw new NotImplementedException();
        }
    }
}
