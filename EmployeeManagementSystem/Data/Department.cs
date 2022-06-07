using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESTAPIproject.Data
{
    public class Department
    {
        [Key]
        public int DId { get; set; }
        public string DepartmentName { get; set; }
    }
}