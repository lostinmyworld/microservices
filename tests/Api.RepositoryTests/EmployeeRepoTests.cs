using Api.Base.Web.Exceptions;
using Api.Data.EfCore.Database;
using Api.Data.EfCore.Repository;
using Api.RepositoryTests.InputParameters;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Api.RepositoryTests
{
    public class EmployeeRepoTests : BaseTest
    {
        private EmployeeRepository _repo;

        public EmployeeRepoTests()
        {
            _repo = new EmployeeRepository(Context);
        }

        #region Get All Employees
        [Fact]
        public async Task GetAll_Success_Test()
        {
            var result = await _repo.GetAll().ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
        #endregion

        #region Get By Name
        [Theory]
        [ClassData(typeof(GetName_ValidName))]
        public async Task GetByName_Success_Test(string name)
        {
            var result = await _repo.GetByNameAsync(name).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetByName_NotFound_Test()
        {
            string name = "Giann";
            var result = await _repo.GetByNameAsync(name).ConfigureAwait(false);

            Assert.NotNull(result);
            Assert.Empty(result);
        }
        #endregion

        #region Get By Id
        [Fact]
        public async Task GetById_Success_Test()
        {
            var id = Context.Employees.First().Id;
            var result = await _repo.Get(id).ConfigureAwait(false);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_NotFound_Test()
        {
            var id = Context.Employees.Last().Id + 100;
            var result = await _repo.Get(id).ConfigureAwait(false);

            Assert.Null(result);
        }
        #endregion

        #region Add
        [Fact]
        public async Task Add_Success_Test()
        {
            var previousCount = Context.Employees.Count();

            var employee = new Employee
            {
                FirstName = "Pana",
                LastName = "Êáôóéìð",
                FathersName = "×ñÞó",
                BirthDate = new DateTime(2000, 1, 1),
                Phone = "+306971234567",
                Email = "exampletest@exampletest.com"
            };

            var result = await _repo.Add(employee).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(previousCount + 1, Context.Employees.Count());
        }

        [Fact]
        public async Task Add_Entity_Null_Test()
        {
            var previousCount = Context.Employees.Count();

            Employee employee = null;

            await Assert.ThrowsAsync<RequestParamNullException>(() =>  _repo.Add(employee)).ConfigureAwait(false);
        }
        #endregion

        #region Generic Update
        [Fact]
        public async Task GenericUpdate_Success_Test()
        {
            var updatedName = "testtesttest";

            var employee = Context.Employees.Last();
            employee.FirstName = updatedName;

            var result = await _repo.GenericUpdate(employee).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(updatedName, Context.Employees.Find(employee.Id).FirstName);
        }

        [Fact]
        public async Task GenericUpdate_Entity_Null_Test()
        {
            Employee employee = null;

            await Assert.ThrowsAsync<RequestParamNullException>(() => _repo.GenericUpdate(employee)).ConfigureAwait(false);
        }
        #endregion

        #region Update
        [Fact]
        public async Task Update_Success_Test()
        {
            var updatedName = "testtesttest";

            var employee = Context.Employees.Last();
            employee.FirstName = updatedName;
            var id = employee.Id;

            var result = await _repo.Update(id, employee).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(updatedName, Context.Employees.Find(employee.Id).FirstName);
        }

        [Fact]
        public async Task Update_Entity_Null_Test()
        {
            var id = Context.Employees.Last().Id;
            Employee employee = null;

            await Assert.ThrowsAsync<RequestParamNullException>(() => _repo.Update(id, employee)).ConfigureAwait(false);
        }

        [Fact]
        public async Task Update_Entity_NotFound_Test()
        {
            var employee = Context.Employees.Last();
            employee.FirstName = "testtesttest";

            var id = employee.Id + 100;

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _repo.Update(id, employee)).ConfigureAwait(false);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_Success_Test()
        {
            var previousCount = Context.Employees.Count();

            await Add_Success_Test().ConfigureAwait(false);

            Assert.Equal(previousCount + 1, Context.Employees.Count());

            var id = Context.Employees.Last().Id;

            var result = await _repo.Delete(id).ConfigureAwait(false);

            Assert.True(result);
            Assert.Equal(previousCount, Context.Employees.Count());
        }

        [Fact]
        public async Task Delete_NotFound_Test()
        {
            var id = Context.Employees.Last().Id + 100;

            await Assert.ThrowsAsync<EntityNotFoundException>(() => _repo.Delete(id)).ConfigureAwait(false);
        }
        #endregion
    }
}
