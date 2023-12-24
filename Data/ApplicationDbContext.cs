using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GOSuiteEmployee.Models;
using System.Reflection.Emit;

namespace GOSuiteEmployee.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GOSuiteEmployee.Models.Employee> Employee { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    EmployeeId = 1,
                    EmployeeName = "John Gomez",
                    Salary = 250000.0,
                    Tenure = 5,
                    Title = "Chief Executive Officer"
                },
                new Employee()
                {
                    Id = 2,
                    EmployeeId = 2,
                    EmployeeName = "Genesis Rea",
                    Salary = 250000.0,
                    Tenure = 5,
                    Title = "Chief Operating Officer"
                },
                new Employee()
                {
                    Id = 3,
                    EmployeeId = 3,
                    EmployeeName = "Jane Doe",
                    Salary = 150000.0,
                    Tenure = 3,
                    Title = "Senior Software Engineer"
                },
                new Employee()
                {
                    Id = 4,
                    EmployeeId = 4,
                    EmployeeName = "John Doe",
                    Salary = 70000.0,
                    Tenure = 1,
                    Title = "Engineering I"
                },
                new Employee()
                {
                    Id = 5,
                    EmployeeId = 5,
                    EmployeeName = "Ash Williams",
                    Salary = 85000.0,
                    Tenure = 3,
                    Title = "Marketing Specialist"
                }
            );
        }
    }
}
