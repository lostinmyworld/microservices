using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace Api.Web.DataAccess.Extensions
{
    internal static class DocumentationExtensions
    {
        internal static IServiceCollection AddDocumentation(this IServiceCollection services)
        {
            services.AddOpenApiDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v0.0.1";
                    document.Info.Title = "Microservices API";
                    document.Info.Description = "Documentation for my personal web API, created by Panagiotis Katsampiris.";
                    document.Info.TermsOfService = "None";
                };
                config.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                config.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            return services;
        }

        internal static IApplicationBuilder UseDocumentation(this IApplicationBuilder app)
        {
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseReDoc();

            return app;
        }
    }
}
