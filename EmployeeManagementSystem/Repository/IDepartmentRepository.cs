using EmployeeManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public interface IDepartmentRepository 
    {
        Task<List<DepartmentModel>> GetAllDeptAsync();
        Task<DepartmentModel> GetDeptById(int id);
        Task<int> AddDeptAsync(DepartmentModel departmentModel);
    }
}
