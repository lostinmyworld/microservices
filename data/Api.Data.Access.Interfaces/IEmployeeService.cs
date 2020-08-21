using Api.Data.Access.DataTypes.DTOs;
using Api.Data.Access.DataTypes.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAll();
        Task<List<EmployeeDTO>> GetAllAsync();

        List<EmployeeDTO> GetByName(NameRequest request);
        Task<List<EmployeeDTO>> GetByNameAsync(NameRequest request);
    }
}
