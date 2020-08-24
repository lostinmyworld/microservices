using Api.Base.Web.Exceptions;
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

        public async Task<bool> Update(long id, Employee updatedEntity)
        {
            var dbEntity = await Get(id).ConfigureAwait(false);
            if (dbEntity == default)
            {
                throw new EntityNotFoundException();
            }

            if (updatedEntity == default)
            {
                throw new RequestParamNullException();
            }

            dbEntity.FirstName = updatedEntity.FirstName;
            dbEntity.LastName = updatedEntity.LastName;
            dbEntity.FathersName = updatedEntity.FathersName;
            dbEntity.Phone = updatedEntity.Phone;
            dbEntity.Email = updatedEntity.Email;
            dbEntity.BirthDate = updatedEntity.BirthDate;

            return await SaveAsync().ConfigureAwait(false);
        }
    }
}
