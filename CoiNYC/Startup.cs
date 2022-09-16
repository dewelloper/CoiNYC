// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using CoiNYC.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Autofac;
using LD.Configuration;
using CoiNYC.Infrastructure;
using ElmahCore.Mvc;
using CoiNYC.Core.Cryptography;
using CoiNYC.Core.CQRS;
using System.Collections.Generic;
using Telerik.Web.Mvc.UI.Fluent;
using CoiNYC.Services;
using CoiNYC.Services.Email;
using CoiNYC.Services.Sms;
using CoiNYC.Core.Data;
using Microsoft.AspNetCore.Mvc;
using Autofac.Core;
using CoiNYC.Features.Home;
using Microsoft.AspNetCore.Mvc.Routing;
using CoiNYC.Core.Helpers;
using Mapster;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Linq;
using CoiNYC.Globalization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CoiNYC.Globalization.Internal;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Serilog;
using Newtonsoft.Json;
using CoiNYC.Domain.Article;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfigurationRoot Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }
        public Startup(IWebHostEnvironment env, IConfiguration conf)
        {
            try
            {
                Environment = env;
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                this.Configuration = builder.Build();
            }
            catch(Exception ex)
            {
                Log.Logger.Error("Program Startup error! Down : " + ex.Message);
            }
        }
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                var generalSettingsMvcClient = Configuration.GetSection("GeneralSettings").Get<GeneralSettingsMvcClient>();
                var connectionString = Configuration.GetConnectionString("DefaultConnection");


                services.AddDbContext<DomainDbContext>(config =>
                 {
                     config.UseSqlServer(connectionString);
                 });

                services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DomainDbContext>();

                //builder.RegisterType<SecuritySettings>().As<SecuritySettings>();

                //services.AddScoped(typeof(IDbContext), typeof(DomainDbContext));
                //services.AddTransient(typeof(IRepository), typeof(GenericRepository));

                services.AddAuthentication(config =>
                {
                    config.DefaultScheme = "Cookie";
                    config.DefaultChallengeScheme = "oidc";
                })
                    .AddCookie("Cookie")
                    .AddOpenIdConnect("oidc", config =>
                    {
                        //config.Authority = "https://localhost:44305/";
                        config.Authority = generalSettingsMvcClient.AppMode == "Local" ? generalSettingsMvcClient.IdentityAuthorityLocal : generalSettingsMvcClient.IdentityAuthorityProduction;
                        config.ClientId = "client_id_mvc";
                        config.ClientSecret = "client_secret_mvc";
                        config.SaveTokens = true;
                        config.ResponseType = "code";
                        config.SignedOutCallbackPath = "/Home/Index";

                    config.ClaimActions.DeleteClaim("amr");
                        config.ClaimActions.DeleteClaim("s_hash");
                        config.ClaimActions.MapUniqueJsonKey("RawCoding.Grandma", "rc.garndma");

                        config.NonceCookie.SameSite = SameSiteMode.None;
                        config.CorrelationCookie.SameSite = SameSiteMode.None;

                    config.GetClaimsFromUserInfoEndpoint = true;

                    config.Scope.Clear();
                        config.Scope.Add("openid");
                        config.Scope.Add("rc.scope");
                        config.Scope.Add("ApiOne");
                        config.Scope.Add("ApiTwo");
                        config.Scope.Add("offline_access");

                    });


                CultureInfo[] supportedCultures = new[]
                {
                new CultureInfo("en"),
                new CultureInfo("tr"),
                new CultureInfo("de"),
                new CultureInfo("nl"),
                new CultureInfo("fa"),
            };

                services.Configure<RequestLocalizationOptions>(options =>
                {
                    options.DefaultRequestCulture = new RequestCulture("en");
                    options.SupportedCultures = supportedCultures;
                    options.SupportedUICultures = supportedCultures;
                    options.RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                    };

                });

                services.AddMvc(options => options.EnableEndpointRouting = false)
                    .AddControllersAsServices()
                    .AddFeatureFolders()
                    .AddAreaFeatureFolders();

                services.AddHttpContextAccessor();

                services.AddHttpClient();
                services.AddControllersWithViews();

                services.AddControllers(options =>
                {
                    options.EnableEndpointRouting = false;

                })
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

                services.AddElmah();

                services.AddDistributedMemoryCache();
                services.AddSession(options =>
                {
                    options.Cookie.Name = ".CoiNYC.Session";
                    options.IdleTimeout = TimeSpan.FromSeconds(10);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;

                });

                services.AddTransient(typeof(BootstrapMvc.Mvc6.BootstrapHelper<>));

                services.AddOptions();
            }
            catch(Exception ex)
            {
                Log.Logger.Error("Program ConfigureServices error! Down : " + ex.Message);
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            try
            {
                if (Environment.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();
                app.UseRouting();
                app.UseElmah();
                var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
                app.UseRequestLocalization(localizationOptions);
                ConfigureComponents();
                app.UseCookiePolicy();
                app.UseAuthentication();
                app.UseAuthorization();
                app.UseSession();

                //ConfigureContainer(app);

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });

                app.UseMvcWithDefaultRoute().UseMvc(routes =>
                    routes.MapRoute(
                        name: "areaRoute",
                        template: "{area:exists}/{controller=Manage}/{action=Index}/{id?}"));

                app.UseMvc();


            }
            catch(Exception ex)
            {
                Log.Logger.Error("Program Configure error! Down : " + ex.Message);
            }
        }

        private static void ConfigureComponents()
        {
            ObjectMapper.Current = new MapsterAdapter();
            DbConfiguration.Loaded += DbConfiguration_Loaded;

            TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;
        }

        private static void DbConfiguration_Loaded(object sender, System.Data.Entity.Infrastructure.DependencyResolution.DbConfigurationLoadedEventArgs e)
        {
            e.ReplaceService<DbProviderServices>((s, k) => System.Data.Entity.SqlServer.SqlProviderServices.Instance);
        }


        // This method will be invoked after aboves for autofac container registeration for Asp.net core 3+
        public void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                RegisterServices(builder);
                RegisterDomain(builder);
                builder.RegisterType<HomeController>().PropertiesAutowired();
            }
            catch (Exception ex)
            {
                Log.Logger.Error("Program ConfigureContainer error! Down : " + ex.Message);
            }
        }

        private static void RegisterDomain(ContainerBuilder builder)
        {
            var domainAssembly = typeof(ArticleDto).Assembly;

            builder.RegisterType<DesAlgorithm>().As<ICryptAlgorithm>().SingleInstance();
            builder.RegisterType<SHA1Algorithm>().As<IHashAlgorithm>().SingleInstance();
            builder.RegisterType<FastHash>().As<IHash64Algorithm>().SingleInstance();

            // CQRS
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            Type handlerType = typeof(IHandler);
            builder.RegisterAssemblyTypes(domainAssembly, Assembly.GetExecutingAssembly())
                 .Where(t => t.IsClass && !t.IsAbstract && handlerType.IsAssignableFrom(t))
                 .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();

            // Repositories
            Type dbContextType = typeof(IDbContext);
            Type repositoryType = typeof(GenericRepository);

            builder.RegisterAssemblyTypes(domainAssembly)
                 .Where(t => t.IsClass && !t.IsAbstract && dbContextType.IsAssignableFrom(t))
                 .AsSelf().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(domainAssembly)
                 .Where(t => t.IsClass && !t.IsAbstract && repositoryType.IsAssignableFrom(t))
                 .AsImplementedInterfaces().InstancePerLifetimeScope();

        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
            builder.RegisterType<LoggingService>().As<ILoggingService>().SingleInstance();
            builder.RegisterType<ManifestService>().As<IManifestService>().InstancePerLifetimeScope();
            builder.RegisterType<RobotsService>().As<IRobotsService>().InstancePerLifetimeScope();

            builder.Register(c => new SitemapService(c.Resolve<ICacheService>(), c.Resolve<ILoggingService>()))
                .As<ISitemapService>()
                .InstancePerLifetimeScope();


            builder.RegisterType<EmailService>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<SmsService>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CurrencyService>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<SettingsService>().AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();

        }



    }
}
