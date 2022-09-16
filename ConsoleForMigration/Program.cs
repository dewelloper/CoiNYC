using CoiNYC.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleForMigration
{
    class Program
    {
        //For IdentityServer
        //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DomainDbContext>
        //{
        //    public DomainDbContext CreateDbContext(string[] args)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //            .AddEnvironmentVariables()
        //            //.SetBasePath(Directory.GetCurrentDirectory())
        //            //.AddJsonFile("appsettings.json")
        //            .Build();
        //        var builder = new DbContextOptionsBuilder<DomainDbContext>();

        //        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //        builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("IdentityServer"));
        //        return new DomainDbContext(builder.Options);
        //    }
        //}


        //For Domain
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DomainDbContext>
        {
            public DomainDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    //.SetBasePath(Directory.GetCurrentDirectory())
                    //.AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<DomainDbContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
                return new DomainDbContext(builder.Options);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
