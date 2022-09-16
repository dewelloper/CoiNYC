//using System;
//using System.Configuration;
//using System.Data.Common;
//using Microsoft.EntityFrameworkCore;
////using System.Data.Entity.Infrastructure;
////using System.Data.Entity.ModelConfiguration;
//using System.Reflection;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using DbContext = Microsoft.EntityFrameworkCore.DbContext;
//using System.Data.Entity.ModelConfiguration;

//namespace CoiNYC.Core.Data
//{
//    public class DbContextBuilder<T> : DbModelBuilder, IDbContextBuilder<T> where T : DbContext
//    {
//        private readonly DbProviderFactory _factory;
//        private readonly ConnectionStringSettings _cnStringSettings;
//        private readonly bool _recreateDatabaseIfExists;
//        private readonly bool _lazyLoadingEnabled;

//        [Obsolete]
//        public DbContextBuilder(string connectionStringName, string[] mappingAssemblies, bool recreateDatabaseIfExists, bool lazyLoadingEnabled)
//        {
//            Conventions.Remove<IncludeMetadataConvention>();

//            _cnStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
//            _factory = DbProviderFactories.GetFactory(_cnStringSettings.ProviderName);
//            _recreateDatabaseIfExists = recreateDatabaseIfExists;
//            _lazyLoadingEnabled = lazyLoadingEnabled;

//            AddConfigurations(mappingAssemblies);
//        }
//        private DbContextBuilder()
//        {
            
//        }
//        public DbContextBuilder(DbModelBuilderVersion modelBuilderVersion)
//            : base(modelBuilderVersion)
//        {
            
//        }

//        public T BuildDbContext()
//        {
//            var cn = _factory.CreateConnection();
//            cn.ConnectionString = _cnStringSettings.ConnectionString;

//            var dbModel = Build(cn);

//            System.Data.Entity.Core.Objects.ObjectContext ctx = dbModel.Compile().CreateObjectContext<System.Data.Entity.Core.Objects.ObjectContext>(cn);
//            ctx.ContextOptions.LazyLoadingEnabled = _lazyLoadingEnabled;

//            if (!ctx.DatabaseExists())
//            {
//                ctx.CreateDatabase();
//            }
//            else if (_recreateDatabaseIfExists)
//            {
//                ctx.DeleteDatabase();
//                ctx.CreateDatabase();
//            }

//            return null;
//            //return (T)new DbContext(ctx, true);
//        }

//        private void AddConfigurations(string[] mappingAssemblies)
//        {
//            if (mappingAssemblies == null || mappingAssemblies.Length == 0)
//            {
//                throw new ArgumentNullException("mappingAssemblies", "You must specify at least one mapping assembly");
//            }

//            bool hasMappingClass = false;
//            foreach (string mappingAssembly in mappingAssemblies)
//            {
//                Assembly asm = Assembly.LoadFrom(MakeLoadReadyAssemblyName(mappingAssembly));

//                foreach (Type type in asm.GetTypes())
//                {
//                    if (!type.IsAbstract)
//                    {
//                        if (type.BaseType.IsGenericType && IsMappingClass(type.BaseType))
//                        {
//                            hasMappingClass = true;
//                            dynamic configurationInstance = Activator.CreateInstance(type);
//                            Configurations.Add(configurationInstance);
//                        }
//                    }
//                }
//            }

//            if (!hasMappingClass)
//            {
//                throw new ArgumentException("No mapping class found!");
//            }
//        }

//        private static bool IsMappingClass(Type mappingType)
//        {
//            Type baseType = typeof(EntityTypeConfiguration<>);
//            if (mappingType.GetGenericTypeDefinition() == baseType)
//            {
//                return true;
//            }
//            if ((mappingType.BaseType != null) &&
//                !mappingType.BaseType.IsAbstract &&
//                mappingType.BaseType.IsGenericType)
//            {
//                return IsMappingClass(mappingType.BaseType);
//            }
//            return false;
//        }

//        private static string MakeLoadReadyAssemblyName(string assemblyName)
//        {
//            return (assemblyName.IndexOf(".dll") == -1)
//                ? assemblyName.Trim() + ".dll"
//                : assemblyName.Trim();
//        }

//    }
//}
