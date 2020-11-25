using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using TourAggregator.Api;
using TourAggregator.Data;
using TourAggregator.Helpers;

namespace hh.gg.TourAggregatorApi
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

        public static void Main(string[] args)
        {

            using (var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
            {
                ILogger logger = loggerFactory.CreateLogger<Program>();

                try
                {
                    logger.LogInformation("Configuring web host ({ApplicationContext})...", AppName);
                    var host = CreateHostBuilder(args).Build();

                    logger.LogInformation("Applying migrations ({ApplicationContext})...", AppName);

                    host.MigrateDbContext<TourDatabaseContext>((context, services) =>
                    {
                        var env = services.GetService<IWebHostEnvironment>();
                        var logger = services.GetService<ILogger<TourDatabaseContextSeed>>();
                        var settings = services.GetService<IOptions<AppSettings>>();

                        new TourDatabaseContextSeed()
                            .SeedAsync(context, logger)
                            .Wait();
                    });

                    logger.LogInformation("Starting web host ({ApplicationContext})...", AppName);
                    host.Run();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                }
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
