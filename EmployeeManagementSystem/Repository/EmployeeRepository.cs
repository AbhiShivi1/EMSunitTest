using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using RESTAPIproject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EMSContext _context;

        public EmployeeRepository(EMSContext context)
        {
            _context = context;
        }
        public bool IsValidDepartment(EmployeeModel emp)
        {
            Department department = _context.Department.FirstOrDefault(x => x.DId == emp.DId);
            if(department==null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<EmployeeModel>> GetAllEmpAsync()
        {
            var emp=await _context.Employee.Select(x=> new EmployeeModel()
            {
                Id=x.Id,
                Name=x.Name,
                Surname=x.Surname,
                DId = x.DId,
                Department = new Department()
                {
                    DId = x.DId,
                    DepartmentName = x.Department.DepartmentName,

                }

            }).ToListAsync();
            return emp;
        }
        public async Task<EmployeeModel> GetEmpByIdAsync(int Id)
        {
            var emp = await _context.Employee.Where(x => x.Id == Id).Select(x => new EmployeeModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                DId = x.DId,
                Department = new Department()
                {
                    DId = x.DId,
                    DepartmentName = x.Department.DepartmentName,

                }


            }).FirstOrDefaultAsync();

            return emp;
        }

        public async Task<int> AddEmpAsync(EmployeeModel employeeModel)
        {
            if(!IsValidDepartment(employeeModel))
            {
                return 999999;

            }
            var emp = new Employee()
            {
                Id = employeeModel.Id,
                Name = employeeModel.Name,
                Surname = employeeModel.Surname,
                DId = employeeModel.DId,
            };
            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return emp.Id;

        }
            

    }
}
