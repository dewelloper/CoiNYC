using System;
using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using IdentityServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace CoiNYC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                            .WriteTo.File(
                                @"C:\Logs\serilogs.txt",
                                fileSizeLimitBytes: 1_000_000,
                                rollOnFileSizeLimit: true,
                                shared: true,
                                flushToDiskInterval: TimeSpan.FromSeconds(1))
                            .CreateLogger();



                var host = CreateHostBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory()).Build();

                host.Run();

                Log.Logger.Information("Host is UP!");

            }
            catch (Exception ex)
            {
                Log.Logger.Error("Program main error! Down : " + ex.Message);
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxConcurrentConnections = 100;
                serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                serverOptions.Limits.MinRequestBodyDataRate =
                    new MinDataRate(bytesPerSecond: 100,
                        gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.MinResponseDataRate =
                    new MinDataRate(bytesPerSecond: 100,
                        gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.KeepAliveTimeout =
                    TimeSpan.FromMinutes(2);
                serverOptions.Limits.RequestHeadersTimeout =
                    TimeSpan.FromMinutes(1);
            })
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>();
        });

    }
}
