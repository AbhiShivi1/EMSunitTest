using RESTAPIproject.Data;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public int DId { get; set; }
        public virtual Department Department { get; set; }
    }
}
