using Api.Web.DataAccess.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Diagnostics;

namespace Api.Web.DataAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = LogExtensions.CreateLoggerFromConfiguration();
                Log.Information("Starting web host");
                Serilog.Debugging.SelfLog.Enable(msg =>
                {
                    Debug.Print(msg);
                    Debugger.Break();
                });

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
