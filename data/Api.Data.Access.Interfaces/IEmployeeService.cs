using Api.Data.Access.DataTypes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllAsync();
        Task<List<EmployeeDTO>> GetByNameAsync(string name);
    }
}
