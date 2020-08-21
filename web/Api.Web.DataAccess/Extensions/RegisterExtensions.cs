using Api.Base.DataTypes;
using Api.Data.Access.Interfaces;
using Api.Data.Access.Services;
using Api.Data.Access.Services.Helpers;
using AutoMapper;
using Microsoft.Extensions.Configuration;
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

        internal static IServiceCollection AddConfigOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var pageSettingsSection = configuration.GetSection("Page");
            if (pageSettingsSection.Exists())
            {
                services.Configure<PageSettings>(pageSettingsSection);
            }

            return services;
        }
    }
}
