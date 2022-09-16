using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;

namespace CoiNYC.Core.Data
{
    public class DbContextManager
    {
        public static void Init(string[] mappingAssemblies, bool recreateDatabaseIfExist = false, bool lazyLoadingEnabled = true)
        {
            Init(DefaultConnectionStringName, mappingAssemblies, recreateDatabaseIfExist, lazyLoadingEnabled);
        }

        [Obsolete]
        public static void Init(string connectionStringName, string[] mappingAssemblies, bool recreateDatabaseIfExist = false, bool lazyLoadingEnabled = true)
        {
            AddConfiguration(connectionStringName, mappingAssemblies, recreateDatabaseIfExist, lazyLoadingEnabled);
        }

        public static void InitStorage(IDbContextStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException("storage");
            }
            if ((_storage != null) && (_storage != storage))
            {
                throw new ApplicationException("A storage mechanism has already been configured for this application");
            }
            _storage = storage;
        }

        public static readonly string DefaultConnectionStringName = "DefaultDb";

        public static DbContext Current
        {
            get
            {
                return CurrentFor(DefaultConnectionStringName);
            }
        }

        public static DbContext CurrentFor(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            if (_storage == null)
            {
                throw new ApplicationException("An IDbContextStorage has not been initialized");
            }

            DbContext context = null;
            lock (_syncLock)
            {
                if (!_dbContextBuilders.ContainsKey(key))
                {
                    throw new ApplicationException("An DbContextBuilder does not exist with a key of " + key);
                }

                context = _storage.GetDbContextForKey(key);

                if (context == null)
                {
                    context = _dbContextBuilders[key].BuildDbContext();
                    _storage.SetDbContextForKey(key, context);
                }
            }
            return context;
        }

        public static void CloseAllDbContexts()
        {
            //foreach (DbContext ctx in _storage.GetAllDbContexts())
            //{
            //    if (((IObjectContextAdapter)ctx).ObjectContext.Connection.State == System.Data.ConnectionState.Open)
            //        ((IObjectContextAdapter)ctx).ObjectContext.Connection.Close();
            //}
        }

        [Obsolete]
        private static void AddConfiguration(string connectionStringName, string[] mappingAssemblies, bool recreateDatabaseIfExists = false, bool lazyLoadingEnabled = true)
        {
            //if (string.IsNullOrEmpty(connectionStringName))
            //{
            //    throw new ArgumentNullException("connectionStringName");
            //}

            //if (mappingAssemblies == null)
            //{
            //    throw new ArgumentNullException("mappingAssemblies");
            //}

            //lock (_syncLock)
            //{
            //    _dbContextBuilders.Add(connectionStringName,
            //        new DbContextBuilder<DbContext>(connectionStringName, mappingAssemblies, recreateDatabaseIfExists, lazyLoadingEnabled));
            //}
        }

        private static IDbContextStorage _storage { get; set; }

        private readonly static Dictionary<string, IDbContextBuilder<DbContext>> _dbContextBuilders = new Dictionary<string, IDbContextBuilder<DbContext>>();
        private readonly static object _syncLock = new object();
    }
}
