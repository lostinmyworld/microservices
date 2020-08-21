using Api.Data.Access.DataTypes.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> Add(EmployeeDTO entity);

        Task<List<EmployeeDTO>> GetAll();
        Task<List<EmployeeDTO>> GetByName(string name);
        Task<EmployeeDTO> GetById(long id);

        Task<bool> Update(long id, EmployeeDTO entity);

        Task<bool> Delete(long id);
    }
}
