using Api.Data.EfCore.Database;
using Api.Data.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Web.DataAccess.Extensions
{
    internal static class DatabaseExtensions
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EntityContext>(options => options
                .EnableSensitiveDataLogging()
                .UseSqlServer(configuration.GetConnectionString("EmployeeDb")));

            services.AddScoped<EmployeeRepository>();

            return services;
        }
    }
}
