using GameStore.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;

namespace GameStore
{
    public abstract class Program

    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var logger = LogManager.Setup()
                       .LoadConfigurationFromAppSettings()
                       .GetCurrentClassLogger();
            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            try
            {
                var host = CreateHostBuilder(args).Build();

                CreateDbIfNotExists(host);

                host.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Application failed to start!");
            }
            finally
            {
                LogManager.Shutdown();
            }

        }


        private static void CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<GameStoreContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseNLog();
    }
}