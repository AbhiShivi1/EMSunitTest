using Microsoft.EntityFrameworkCore;

namespace RESTAPIproject.Data
{
    public class EMSContext :DbContext
    {
        public EMSContext(DbContextOptions<EMSContext> options):base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        


    }
}
