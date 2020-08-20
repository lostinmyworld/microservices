using Api.Data.EfCore.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Web.DataAccess.Extensions
{
    internal static class RegisterExtensions
    {
        internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<EmployeeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("EmployeeDb")));

            return services;
        }

        internal static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
