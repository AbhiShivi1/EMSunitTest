using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using RESTAPIproject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EMSContext _context;

        public DepartmentRepository(EMSContext context)
        {
            _context = context;
        }

        public async Task<List<DepartmentModel>> GetAllDeptAsync()
        {
            var dept = await _context.Department.Select(x => new DepartmentModel()
            {
                DId=x.DId,
                DepartmentName=x.DepartmentName,

            }).ToListAsync();
            return dept;
        }
        public async Task<DepartmentModel> GetDeptById(int id)
        {
            var dept = await _context.Department.Where(x => x.DId == id).Select(x => new DepartmentModel()
            {
                DId=x.DId,
                DepartmentName=x.DepartmentName,

            }).FirstOrDefaultAsync();
            return dept;
        }

        public async Task<int> AddDeptAsync(DepartmentModel departmentModel)
        {
            var dept = new Department()
            {
                DId = departmentModel.DId,
                DepartmentName = departmentModel.DepartmentName,
            };
            _context.Department.Add(dept);
            await _context.SaveChangesAsync();
            return dept.DId;
        }
    }
}
