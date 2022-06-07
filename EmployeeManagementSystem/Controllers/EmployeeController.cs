using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPIproject.Data;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmp()
        {
            var emp = await _employeeRepository.GetAllEmpAsync();
            return Ok(emp);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpById([FromRoute]int id)
        {
            var emp = await _employeeRepository.GetEmpByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmp([FromBody]EmployeeModel employeeModel)
        {
            var id = await _employeeRepository.AddEmpAsync(employeeModel);
            if(id== 999999)
            {
                return BadRequest();
            }
            
            return CreatedAtAction(nameof(GetEmpById), new { id = id, Controller = "Employee" }, id);
        }
    }
}
