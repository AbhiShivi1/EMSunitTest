using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NUnit.Framework;
using RESTAPIproject.Data;
using System.Linq;

namespace EmployeeManagementSystemTests
{
    [TestClass]
    public class EMSunitTests
    {
        private DbContextOptions<EMSContext> dbContextOptions = new DbContextOptionsBuilder<EMSContext>()
            .UseInMemoryDatabase(databaseName:"EMSTest")
              .Options;
        EMSContext context;

        [TestInitialize]
        public void setup()
        {
            context = new EMSContext(dbContextOptions);
            context.Database.EnsureCreated();
            context.Department.Add(new Department { DId = 1, DepartmentName = "HR" });
            context.Department.Add(new Department { DId = 2, DepartmentName = "Sales" });
            context.Employee.Add(new Employee { Id = 1, Name = "Abhinav", Surname = "Maurya", DId = 1 });
            context.Employee.Add(new Employee { Id = 2, Name = "Rajesh", Surname = "Khanna", DId = 1 });
            context.Employee.Add(new Employee { Id = 3, Name = "Ankita", Surname = "Verma", DId = 2 });
            context.SaveChanges();
        }
        [TestCleanup]
        public void Clearup()
        {
            context.Database.EnsureDeleted();
        }



        [TestMethod]
        public void AddEmployeeAsync_ChecksValidData_throwsExceptionIfInvalid()
        {
           context.Employee.Add(new Employee
            {
                Id = 5,
                Name = "danish",
                Surname = "Khan"
            });
            var DepartmentId = context.Employee.Find(5).DId;
            if (DepartmentId == 0)
                throw new AssertFailedException("Invalid Data"); // throws exception as DepartmentId is 0
            context.SaveChanges();

            

        }
        [TestMethod]
        public void AddEmployeeAsync_IfValidData_AddDataToDb()
        {
            context.Employee.Add(new Employee
            {
                Id = 7,
                Name = "danish",
                Surname = "Khan",
                DId=1
            });
           
            context.SaveChanges();
            var count = context.Employee.Count();
            Assert.AreEqual(4, count);              //Emo=ployee gets added and its count increases from 3 to 4




        }
        [TestMethod]
        public void GetEmpData_ChecksIfdatapresent_throwsExceptionIfNoData()
        {
            var Emp = context.Employee;
            var Dept = context.Department;
            var Mapping = (from x in Emp
                           join y in
                           Dept on x.DId equals y.DId
                           where x.Id == 10000
                           select new
                           {
                               Id = x.Id,
                               Name = x.Name,
                               Surname = x.Surname,
                               DepartmentName = y.DepartmentName
                           }).FirstAsync();
            if(Mapping==null)
            {
                throw new AssertFailedException("no data available");
            }
            Assert.IsNotNull(Mapping);



                

        }
        [TestMethod]
        public void GetNumberOfEmp_sumOfEmpbyDept_ReturnsSumOfEmpFromSameDept()
        {
            var TotalEmp = context.Employee.Count(x => x.DId == 2);
            Assert.AreEqual(1, TotalEmp);
        }
    }
}
