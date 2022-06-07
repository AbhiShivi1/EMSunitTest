using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllDept()
        {
            var dept = await _departmentRepository.GetAllDeptAsync();
            return Ok(dept);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeptById([FromRoute]int id)
        {
            var dept = await _departmentRepository.GetDeptById(id);
            if(dept==null)
            {
                return NotFound();
            }
            return Ok(dept);
        }
        [HttpPost]
        public async Task<IActionResult> AddDept([FromBody]DepartmentModel departmentModel)
        {
            var Id = await _departmentRepository.AddDeptAsync(departmentModel);
            return CreatedAtAction(nameof(GetDeptById), new { id = Id, Controller = "Department" }, Id);
        }

    }
}
