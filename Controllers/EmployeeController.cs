using ASP.MongoDb.API.Entity;
using ASP.MongoDb.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.MongoDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //invoke the interface
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //http get method to get all employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(employees);
        }

        //http get method to get employee by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
       
        //http post method to create new employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] AddUpdateEmployee addEmployee)
        {
            if (addEmployee == null)
            {
                return BadRequest("Employee cannot be null");
            }
            var employee = new Employee
            {
                
                Name = addEmployee.Name,
                Age = addEmployee.Age

            };
            await _employeeRepository.CreateAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        //http put method to update an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] AddUpdateEmployee updateEmployee)
        {
            if (updateEmployee == null)
            {
                return BadRequest("Employee data is invalid");
            }
            var employee = new Employee
            {
                Id=id,
                Name = updateEmployee.Name,
                Age = updateEmployee.Age

            };
            await _employeeRepository.UpdateAsync(id, employee);
            return Ok(employee);
        }

        //http delete method to delete the employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await _employeeRepository.DeleteAsync(id);
            return Ok(new { Success =true, Message="Product deleted"});
        }
        

    }
}
