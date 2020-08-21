using Api.Data.Access.DataTypes.DTOs;
using Api.Data.Access.DataTypes.Requests;
using Api.Data.Access.Interfaces;
using Api.Data.Access.Services.Helpers;
using Api.Data.EfCore.Repository;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Data.Access.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        #region Retrieve All
        public List<EmployeeDTO> GetAll()
        {
            var dbEntities = _employeeRepo.GetAll();

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var dbEntities = await _employeeRepo.GetAllAsync().ConfigureAwait(false);

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }
        #endregion

        #region Retrieve by Name
        public List<EmployeeDTO> GetByName(NameRequest request)
        {
            request.Validate();

            var dbEntities = _employeeRepo.GetByName(request.Name);

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }

        public async Task<List<EmployeeDTO>> GetByNameAsync(NameRequest request)
        {
            request.Validate();

            var dbEntities = await _employeeRepo.GetByNameAsync(request.Name).ConfigureAwait(false);

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }
        #endregion
    }
}
