using System;

namespace CoiNYC.Core.Data
{
    public class DbContextInitializer
    {
        private static readonly object _syncLock = new object();
        private static DbContextInitializer _instance;

        protected DbContextInitializer() { }

        private bool _isInitialized = false;

        public static DbContextInitializer Instance()
        {
            if (_instance == null)
            {
                lock (_syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DbContextInitializer();
                    }
                }
            }

            return _instance;
        }

        /// DbContextInitializer.Instance().InitializeDbContextOnce(() => InitializeDbContext());
        /// where InitializeDbContext() is a method which calls DbContextManager.Init()
        public void InitializeDbContextOnce(Action initMethod)
        {
            lock (_syncLock)
            {
                if (!_isInitialized)
                {
                    initMethod();
                    _isInitialized = true;
                }
            }
        }
    }
}
