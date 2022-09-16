using CoiNYC.Domain.Repositories;
using IdentityServer.Infrastructure;
using IdentityServer.Resources;
using IdentityServer4.EntityFramework.Stores;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        public IWebHostEnvironment Environment { get; }
        public IConfigurationRoot ConfigurationRoot { get; private set; }

        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            try
            {
                _config = config;
                _env = env;

                Environment = env;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                this.ConfigurationRoot = builder.Build();
            }
            catch (Exception ex)
            {
                Log.Logger.Error("IdentityServer4 Program Startup error! Down : " + ex.Message);
            }
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //var generalSettingsIdentity4 = ConfigurationRoot.GetSection("AppSettings:GeneralSettingsIdentity4").Get<GeneralSettingsIdentity4>();
            var connectionString = _config.GetConnectionString("DefaultConnection");

            services.AddDbContext<DomainDbContext>(config =>
            {
                config.UseSqlServer(connectionString);
                //config.UseInMemoryDatabase("Memory");
            });


            // AddIdentity registers the services
            services.AddIdentity<ApplicationUser, ApplicationRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<DomainDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "IdentityServer.Cookie";
                config.LoginPath = "/Auth/Login";
                config.LogoutPath = "/Auth/Logout";
            });

            var assembly = typeof(Startup).Assembly.GetName().Name;

            //var filePath = Path.Combine(_env.ContentRootPath, "is_cert.pfx");
            //var certificate = new X509Certificate2(filePath, "password");


            services.AddIdentityServer()
                .AddAspNetIdentity<ApplicationUser>()
                //.AddConfigurationStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                //        sql => sql.MigrationsAssembly(assembly));
                //})
                //.AddOperationalStore(options =>
                //{
                //    options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
                //        sql => sql.MigrationsAssembly(assembly));
                //})
                //.AddSigningCredential(certificate);
                .AddInMemoryApiResources(Configuration.GetApis())
                .AddInMemoryIdentityResources(Configuration.GetIdentityResources())
                .AddInMemoryClients(Configuration.GetClients())
                .AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddFacebook(config => {
                    config.AppId = "3396617443742614";
                    config.AppSecret = "secret";
                });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });


        }
    }
}
