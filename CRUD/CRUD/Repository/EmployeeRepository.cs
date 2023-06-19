using CRUD.DB_Context;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyContext _companyContext;
        public EmployeeRepository(CompanyContext companyContext) 
        {
            _companyContext = companyContext;
        }

        public async Task<IEnumerable<EmployeeObj>> EmployeesList() 
        {
            return (IEnumerable<EmployeeObj>)await _companyContext.Employees
                .Join(_companyContext.Departments, employee => employee.Departmentid, department => department.Id,
                (employee, department) => new { Employee = employee, Department = department })
                .Join(_companyContext.Statuses, employee => employee.Employee.Statusid, status => status.Id,
                (employee, status) => new { employee.Employee, employee.Department, Status = status })
                .Select(e => new EmployeeObj
                {
                    Id = e.Employee.Id,
                    Department = e.Department.Name,
                    Name = e.Employee.Name,
                    Status = e.Status.Statusname,
                    DateOfBirth = e.Employee.Dateofbirth,
                    EmploymentDate = e.Employee.Employmentdate,
                    Salary = e.Employee.Salary
                }).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> CurrentEmployee(int ID) 
        {
            return (IEnumerable<EmployeeObj>)await _companyContext.Employees
                .Join(_companyContext.Departments, employee => employee.Departmentid, department => department.Id,
                (employee, department) => new { Employee = employee, Department = department })
                .Join(_companyContext.Statuses, employee => employee.Employee.Statusid, status => status.Id,
                (employee, status) => new { employee.Employee, employee.Department, Status = status })
                .Select(e => new EmployeeObj
                {
                    Id = e.Employee.Id,
                    Department = e.Department.Name,
                    Name = e.Employee.Name,
                    Status = e.Status.Statusname,
                    DateOfBirth = e.Employee.Dateofbirth,
                    EmploymentDate = e.Employee.Employmentdate,
                    Salary = e.Employee.Salary
                }).Where(employee => employee.Id == ID).ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee objEmployee) 
        {
            _companyContext.Entry(objEmployee).State = EntityState.Modified;
            await _companyContext.SaveChangesAsync();

            return objEmployee;
        }

        public async Task<Employee> AddEmployee(Employee objEmployee) 
        {
            _companyContext.Employees.Add(objEmployee);
            await _companyContext.SaveChangesAsync();

            return objEmployee;
        }

        public bool DeleteEmployee(int ID) 
        {
            bool result = false;

            var employee = _companyContext.Employees.Find(ID);

            if (employee != null)
            {
                _companyContext.Entry(employee).State = EntityState.Deleted;
                _companyContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
