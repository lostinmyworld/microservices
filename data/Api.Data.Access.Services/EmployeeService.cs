using Api.Data.Access.DataTypes.DTOs;
using Api.Data.Access.Interfaces;
using Api.Data.EfCore.Database;
using Api.Data.EfCore.Repository;
using AutoMapper;
using System;
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

        #region Create
        public async Task<bool> Add(EmployeeDTO entity)
        {
            var dbEntity = _mapper.Map<Employee>(entity);

            return await _employeeRepo.Add(dbEntity).ConfigureAwait(false);
        }
        #endregion

        #region Retrieve
        public async Task<List<EmployeeDTO>> GetAll()
        {
            var dbEntities = await _employeeRepo.GetAll().ConfigureAwait(false);

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }

        public async Task<List<EmployeeDTO>> GetByName(string name)
        {
            var dbEntities = await _employeeRepo.GetByNameAsync(name).ConfigureAwait(false);

            return _mapper.Map<List<EmployeeDTO>>(dbEntities);
        }

        public async Task<EmployeeDTO> GetById(long id)
        {
            var dbEntity = await _employeeRepo.Get(id).ConfigureAwait(false);

            return _mapper.Map<EmployeeDTO>(dbEntity);
        }
        #endregion

        #region Update
        public async Task<bool> Update(long id, EmployeeDTO entity)
        {
            if (entity == default)
            {

            }
            var dbEntity = _mapper.Map<Employee>(entity);

            return await _employeeRepo.Update(id, dbEntity).ConfigureAwait(false);
        }
        #endregion

        #region Delete
        public async Task<bool> Delete(long id)
        {
            return await _employeeRepo.Delete(id).ConfigureAwait(false);
        }
        #endregion
    }
}
