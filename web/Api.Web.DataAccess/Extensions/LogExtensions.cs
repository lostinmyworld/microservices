using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Api.Web.DataAccess.Extensions
{
    internal static class LogExtensions
    {
        internal static ILogger CreateLoggerFromConfiguration()
        {
            var configuration = RetrieveAppSettingsConfiguration();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static IConfiguration RetrieveAppSettingsConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .Build();
        }
    }
}
