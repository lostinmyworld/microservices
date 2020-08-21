using Api.Data.Access.DataTypes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAll();
        Task<List<EmployeeDTO>> GetAllAsync();

        List<EmployeeDTO> GetByName(string name);
        Task<List<EmployeeDTO>> GetByNameAsync(string name);
    }
}
