using CRUD.Models;

namespace CRUD.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeObj>> EmployeesList();
        Task<IEnumerable<Employee>> CurrentEmployee(int Id);
        Task<Employee> AddEmployee(Employee objEmployee);
        Task<Employee> UpdateEmployee(Employee objEmployee);
        bool DeleteEmployee(int Id);
        Task<IEnumerable<Department>> DepartmentsList();
    }
}
