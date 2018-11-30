using Employees.Model;
using Employees.Models;
using Employees.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Employees.Controllers
{
    public class EmployeesController : ApiController
    {

        private IEmployeeRepository _employeeRepository;

        private static readonly log4net.ILog log = /*LogHelper.GetLogger();*/ log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            //we can use dependency injection like Ninject :) but for now 
            //manual instantiation
            _employeeRepository = employeeRepository;

        }

        public IHttpActionResult GetEmployees()
        {

            List<Employee> list;
            list = _employeeRepository.GetEmployees();

            log.Info(DateTime.Now);
            log.Info("Method: GetEmployees()");
            log.Info("Request Url: " + Url.Request.RequestUri);
            log.Info("HTTP Method: " + Url.Request.Method);
            for (int i = 0; i < list.Count; i++)
            {
                log.Info("Id: " + list[i].id);
                log.Info("Name: " + list[i].name);
                log.Info("Surname: " + list[i].surname);
                log.Info("Age: " + list[i].age);
                log.Info("Department Id: " + list[i].departmentId);
                log.Info("Active: " + list[i].active);
                log.Info("");
            }
            log.Info("-------------------------------------------------------------");

            return Ok(list);
        }

        public IHttpActionResult CreateEmployee(Employee egm)
        {
            try
            {
                List<Employee> list = _employeeRepository.PostEmployee(egm);
                return Ok(list);
            }
            catch (Exception e)
            {
                log.Error(e);
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, e));
            }
        }

        public IHttpActionResult DeleteEmployee(int id)
        {
            log.Info(DateTime.Now);
            log.Info("Method: DeleteEmployee(int id: " + id + ")");
            log.Info("Request Url: " + Url.Request.RequestUri);
            log.Info("HTTP Method: " + Url.Request.Method);
            Employee employeeById = _employeeRepository.GetEmpById(id);
            log.Info("Id: " + employeeById.id);
            log.Info("Name: " + employeeById.name);
            log.Info("Surname: " + employeeById.surname);
            log.Info("Age: " + employeeById.age);
            log.Info("Department Id: " + employeeById.departmentId);
            log.Info("Active: " + employeeById.active);
            log.Info("");
            log.Info("-------------------------------------------------------------");

            List<Employee> allEmployees = _employeeRepository.DeleteEmployee(id);
       
            return Ok(allEmployees);
        }

        public IHttpActionResult GetEmployeeById(int id)
        {
            Employee employeeById = _employeeRepository.GetEmpById(id);

            log.Info(DateTime.Now);
            log.Info("Method: GetEmployeeById(int id: " + id + ")");
            log.Info("Request Url: " + Url.Request.RequestUri);
            log.Info("HTTP Method: " + Url.Request.Method);

            log.Info("Id: " + employeeById.id);
            log.Info("Name: " + employeeById.name);
            log.Info("Surname: " + employeeById.surname);
            log.Info("Age: " + employeeById.age);
            log.Info("Department Id: " + employeeById.departmentId);
            log.Info("Active: " + employeeById.active);
            log.Info("");

            log.Info("-------------------------------------------------------------");

            if (employeeById != null)
            {
                return Ok(employeeById);
            }
            else
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Id not found."));
            }

        }

        public IHttpActionResult Put(int id, Employee egm)
        {

            Employee updatedEmployee = _employeeRepository.UpdateEMploye(id, egm);
            return Ok(updatedEmployee);
        }
        [Route("api/employees/{x:bool}")]
        public IHttpActionResult GetActiveOr(bool x)
        {
            List<Employee> actOrinAct = _employeeRepository.ActOrInactive(x);
            return Ok(actOrinAct);
        }

        [Route("api/department/{departmentId}/employees")]
        public IHttpActionResult GetEmployeesDepartment(int departmentId)
        {
            log.Info(Url.Request.RequestUri);
            List<Employee> empDepartment = _employeeRepository.EmployeeDepartment(departmentId);
            return Ok(empDepartment);
        }

        [Route("api/department/{departmentId}/employees/{x:bool}")]
        public IHttpActionResult GetEmployeesDepartment(int departmentId, bool x)
        {
            List<Employee> empDepartment = _employeeRepository.EmployeeDepartmentActive(departmentId, x);
            return Ok(empDepartment);
        }
    }
}
