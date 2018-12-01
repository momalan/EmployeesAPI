# EmployeesAPI
This is a simple backend solution for employees - CRUD.

Available endpoints:
- GET `../api/employees`  -->  Get all employees.
- GET `../api/employees/{true|false}`  -->  Get all active or inactive employees.
- GET `../api/employees/{id}`  -->  Get employee based on employee id.

- GET `../api/department/{departmentId}/employees`  -->  Get employees based on department(0-developmnet, 1-management, 2-HR).
By default, endpoint returns active employees but it should be possible to return inactive: `..api/department/{departmentId}/employees/{true|false}` 

- POST `..api/employees`  -->  Create new employee.
- PUT `..api/employees`  -->  Update existing employee.
- DELETE `..api/employees/{id}`  -->  Delete existing employee.

In solution is included logging(log4net) for next endpoints: (Update is coming soon)
- GET `../api/employees`
- GET `../api/employees/{id}`
- DELETE `..api/employees/{id}`

To run this project you have to load the solution using `Employees.sln` into Visual Studio. 

Update `Web.config` file: 

<log4net>
FileAppender
    
      <file value="C:\Users\muham\Desktop\EmployeesForSurface\Employees\MyLogFile.txt" />
      
RollingAppender
    
      <file value="C:\Users\muham\Desktop\EmployeesForSurface\Employees\RollingFileLog.txt" />
        
RUN! :)
