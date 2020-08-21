using Api.Data.EfCore.Database;
using Api.Data.EfCore.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.EfCore.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(EntityContext context)
            : base(context)
        {
        }

        public List<Employee> GetByName(string name)
        {
            return Context.Employees.AsNoTracking()
                .Where(e => EF.Functions.Like(e.FirstName, $"%{name}%") || EF.Functions.Like(e.LastName, $"%{name}%"))
                .ToList();
        }

        public async Task<List<Employee>> GetByNameAsync(string name)
        {
            return await Context.Employees.AsNoTracking()
                .Where(e => EF.Functions.Like(e.FirstName, $"%{name}%") || EF.Functions.Like(e.LastName, $"%{name}%"))
                .ToListAsync().ConfigureAwait(false);
        }
    }
}
