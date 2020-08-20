using Api.Data.EfCore.Database;
using Api.Data.EfCore.Repository.Base;

namespace Api.Data.EfCore.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(EmployeeContext context)
            : base(context)
        {
        }
    }
}
