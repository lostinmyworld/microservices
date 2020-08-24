using Api.Data.EfCore.Database;
using Api.RepositoryTests.MockData;
using Microsoft.EntityFrameworkCore;
using System;

namespace Api.RepositoryTests
{
    public abstract class BaseTest : IDisposable
    {
        protected readonly EntityContext Context;

        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<EntityContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;

            Context = new EntityContext(options);

            Context.Database.EnsureCreated();

            SeedData();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
        }

        private void SeedData()
        {
            Context.Employees.AddRange(EmployeeData.Employees);

            Context.SaveChanges();
        }
    }
}
