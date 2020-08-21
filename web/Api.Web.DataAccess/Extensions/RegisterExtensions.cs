using Api.Data.Access.Interfaces;
using Api.Data.Access.Services;
using Api.Data.Access.Services.Helpers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Web.DataAccess.Extensions
{
    internal static class RegisterExtensions
    {
        internal static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddAutoMapper(mapperConfig =>
            {
                mapperConfig.AddProfile<DataAccessMapping>();
            });

            return services;
        }
    }
}
