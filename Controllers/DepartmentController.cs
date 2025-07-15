using ASP.MongoDb.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.MongoDb.API.Entity;

namespace ASP.MongoDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        // HTTP GET method to get all departments
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(departments);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDepartmentById(string id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }
        // HTTP POST method to create a new department
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] AddUpdateDepartment addDepartment)
        {
            if (addDepartment == null)
            {
                return BadRequest("Department cannot be null");
            }

            // Map AddUpdateDepartment to Department  
            var department = new Department
            { 
                DepartmentName = addDepartment.DepartmentName,
                DepartmentLocation = addDepartment.DepartmentLocation
            };

            await _departmentRepository.CreateAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }


        // HTTP PUT method to update an existing department
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDepartment(string id, [FromBody] AddUpdateDepartment updateDepartment)
        {
            if (updateDepartment == null)
            {
                return BadRequest("Department data is invalid");
            }
            var department = new Department
            {
                Id = id,
                DepartmentName = updateDepartment.DepartmentName,
                DepartmentLocation = updateDepartment.DepartmentLocation
            };
            await _departmentRepository.UpdateAsync(id, department);
            return Ok(department);
        }
        // HTTP DELETE method to delete a department
        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(string id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            await _departmentRepository.DeleteAsync(id);
            return NoContent();
        }


    }
}
