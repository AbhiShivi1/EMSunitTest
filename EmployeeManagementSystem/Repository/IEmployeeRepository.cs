using EmployeeManagementSystem.Models;
using RESTAPIproject.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Repository
{
    public interface IEmployeeRepository 
    {
        Task<List<EmployeeModel>> GetAllEmpAsync();
        Task<EmployeeModel> GetEmpByIdAsync(int Id);
        Task<int> AddEmpAsync(EmployeeModel employeeModel);
    }
}
