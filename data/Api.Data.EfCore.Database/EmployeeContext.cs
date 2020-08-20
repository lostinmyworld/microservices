using Microsoft.EntityFrameworkCore;

namespace Api.Data.EfCore.Database
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
