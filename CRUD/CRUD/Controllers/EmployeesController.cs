using CRUD.Models;
using CRUD.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        public EmployeesController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet]
        [Route("EmployeesList")]
        public async Task<IActionResult> EmployeesList()
        {
            return Ok(await _employee.EmployeesList());
        }

        [HttpGet]
        [Route("CurrentEmployee/{Id}")]
        public async Task<IActionResult> CurrentEmployee(int Id)
        {
            return Ok(await _employee.CurrentEmployee(Id));
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await _employee.AddEmployee(employee);
            return Ok("Employee added");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await _employee.UpdateEmployee(employee);
            return Ok("employee updated");
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public JsonResult DeleteEmployee(int id) 
        {
            _employee.DeleteEmployee(id);
            return new JsonResult("Employee deleted");
        }

        [HttpGet]
        [Route("DepartmentsList")]
        public async Task<IActionResult> DepartmentsList() 
        {
            return Ok(await _employee.DepartmentsList());
        }
    }
}
