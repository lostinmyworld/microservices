using Api.Base.Web.Exceptions;
using Api.Data.Access.DataTypes.DTOs;
using Api.Data.Access.Interfaces;
using Api.Data.Access.Services;
using Api.Data.Access.Services.Helpers;
using Api.Data.EfCore.Repository;
using Api.RepositoryTests;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.ServiceTests
{
    public class EmployeeServiceTests : BaseTest
    {
        private readonly IEmployeeService _service;
        private readonly IMapper _mapper;

        public EmployeeServiceTests()
        {
            var repo = new EmployeeRepository(Context);

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<DataAccessMapping>();
            });
            _mapper = mapperConfig.CreateMapper();

            _service = new EmployeeService(repo, _mapper);
        }

        #region Add
        [Fact]
        public async Task Add_Success_Test()
        {
            var employee = new EmployeeDTO
            {
                FirstName = "Παναγιώρ",
                LastName = "Κατσιμπ",
                FathersName = "Χρήσ",
                BirthDate = new DateTime(2000, 1, 1),
                Phone = "+306971234567",
                Email = "exampletest@exampletest.com"
            };

            var result = await _service.Add(employee).ConfigureAwait(false);

            Assert.True(result);
        }

        [Fact]
        public async Task Add_Entity_Null_Test()
        {
            EmployeeDTO employee = null;

            await Assert.ThrowsAsync<RequestParamNullException>(() => _service.Add(employee)).ConfigureAwait(false);
        }
        #endregion

        #region Get All
        [Fact]
        public async Task GetAll_Success_Test()
        {
            var result = await _service.GetAll().ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        #endregion

        #region Get By Name
        [Fact]
        public async Task GetByName_Success_Test()
        {
            var name = "Παναγιώρ";

            var result = await _service.GetByName(name).ConfigureAwait(false);

            Assert.NotNull(result);
        }
        #endregion

        #region Get By Id
        [Fact]
        public async Task GetById_Success_Test()
        {
            var id = Context.Employees.First().Id;

            var result = await _service.GetById(id).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_NotFound_Test()
        {
            var id = Context.Employees.Last().Id + 100;

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.GetById(id)).ConfigureAwait(false);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            var updatedName = "testtesttest3";

            var employee = Context.Employees.Last();
            var id = employee.Id;

            var employeeDto = _mapper.Map<EmployeeDTO>(employee);
            employeeDto.FirstName = updatedName;

            var result = await _service.Update(id, employeeDto).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(updatedName, Context.Employees.Find(employee.Id).FirstName);
        }

        [Fact]
        public async Task Update_Entity_Null_Test()
        {
            var id = Context.Employees.Last().Id;
            EmployeeDTO employeeDto = null;

            await Assert.ThrowsAsync<RequestParamNullException>(() => _service.Update(id, employeeDto)).ConfigureAwait(false);
        }

        [Fact]
        public async Task Update_Entity_NotFound_Test()
        {
            var employee = Context.Employees.Last();
            employee.FirstName = "testtesttest";
            var employeeDto = _mapper.Map<EmployeeDTO>(employee);

            var id = employee.Id + 100;

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _service.Update(id, employeeDto)).ConfigureAwait(false);
        }
        #endregion
    }
}
