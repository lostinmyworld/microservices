using Api.Data.Access.DataTypes.DTOs;
using Api.Data.Access.Interfaces;
using Api.Data.EfCore.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;

        public EmployeeService(EmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public List<EmployeeDTO> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<EmployeeDTO>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public List<EmployeeDTO> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<EmployeeDTO>> GetByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
