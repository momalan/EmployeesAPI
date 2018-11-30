using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employees.Repository;
using Employees.Model;


namespace Employees.Repository.Mock
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> employees;

        public EmployeeRepository()
        {
            if (employees == null)
            {
                InitMocData();
            }
        }

        public List<Employee> ActOrInactive(bool x)
        {
            List<Employee> listOfall = GetEmployees();
            var thisEmployees = listOfall.Where(y => y.active == x).ToList();
            return thisEmployees;
        }

        public List<Employee> DeleteEmployee(int id)
        {
            List<Employee> listOfall = GetEmployees();
            Employee deleteThis = listOfall.FirstOrDefault(x => x.id == id);
            listOfall.Remove(deleteThis);
            return listOfall;
        }

        public List<Employee> EmployeeDepartment(int d)
        {
            List<Employee> listOfall = GetEmployees();
            var empDepartmenrId = listOfall.Where(y => y.departmentId == d && y.active == true).ToList();
            return empDepartmenrId;
        }

        public List<Employee> EmployeeDepartmentActive(int d, bool x)
        {
            List<Employee> listOfall = GetEmployees();
            var empDepartmenrIdActive = listOfall.Where(y => y.departmentId == d && y.active == x).ToList();
            return empDepartmenrIdActive;
        }

        public Employee GetEmpById(int id)
        {
            List<Employee> allEmployees = GetEmployees();
            Employee employee = allEmployees.FirstOrDefault(x => x.id == id);
            return employee;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public List<Employee> PostEmployee(Employee e)
        {
            List<Employee> employees = GetEmployees();
            Employee egm5 = new Employee();
            egm5.id = 5;
            egm5.name = e.name;
            egm5.surname = e.surname;
            egm5.age = e.age;
            egm5.active = e.active;
            egm5.departmentId = e.departmentId;
            employees.Add(egm5);
            return employees;
        }

        public Employee UpdateEMploye(int id, Employee egm)
        {
            List<Employee> listOfAll = GetEmployees();
            Employee employeeForUpdate = listOfAll.FirstOrDefault(x => x.id == id);
            if (egm.name != null)
            {
                employeeForUpdate.name = egm.name;
            }
            if (egm.surname != null)
            {
                employeeForUpdate.surname = egm.surname;
            }
            if (egm.age > 0)
            {
                employeeForUpdate.age = egm.age;
            }
            if (employeeForUpdate.active != egm.active)
            {
                employeeForUpdate.active = egm.active;
            }
            if (employeeForUpdate.departmentId != egm.departmentId)
            {
                employeeForUpdate.surname = egm.surname;
            }
            return employeeForUpdate;
        }


        private void InitMocData()
        {
            employees = new List<Employee>();

            Employee egm = new Employee();
            egm.id = 1;
            egm.name = "Muhammed";
            egm.surname = "Malanovic";
            egm.age = 25;
            egm.active = true;
            egm.departmentId = 0;
            employees.Add(egm);
            Employee egm2 = new Employee();
            egm2.id = 2;
            egm2.name = "John";
            egm2.surname = "Casper";
            egm2.age = 28;
            egm2.active = false;
            egm2.departmentId = 0;
            employees.Add(egm2);
            Employee egm3 = new Employee();
            egm3.id = 3;
            egm3.name = "Johnatan";
            egm3.surname = "Atkinson";
            egm3.age = 282;
            egm3.active = true;
            egm3.departmentId = 2;
            employees.Add(egm3);
            Employee egm4 = new Employee();
            egm4.id = 4;
            egm4.name = "Johnatan";
            egm4.surname = "Atkinson";
            egm4.age = 282;
            egm4.active = true;
            egm4.departmentId = 1;
            employees.Add(egm4);
        }
    }
}
