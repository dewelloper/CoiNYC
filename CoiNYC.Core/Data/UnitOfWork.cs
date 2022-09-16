using System;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using CoiNYC.Core.Data;

namespace CoiNYC.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbTransaction _transaction;
        private DbContext _dbContext;
        private int _transactionRefCount;

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public bool IsInTransaction
        {
            get { return _transaction != null; }
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            //if (_transaction != null)
            //{
            //    _transactionRefCount++;
            //    return;
            //    /*
            //    throw new ApplicationException("Cannot begin a new transaction while an existing transaction is still running. " +
            //                                    "Please commit or rollback the existing transaction before starting a new one.");
            //     */
            //}
            //OpenConnection();
            //_transaction = ((IObjectContextAdapter)_dbContext).ObjectContext.Connection.BeginTransaction(isolationLevel);
            //_transactionRefCount = 1;

            _dbContext.ChangeTracker.Context.Database.BeginTransaction();
        }

        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            if (IsInTransaction)
            {
                _transactionRefCount--;
                if (_transactionRefCount <= 0)
                {
                    _transaction.Rollback();
                    ReleaseCurrentTransaction();
                }
            }
        }

        public void CommitTransaction()
        {
            //if (_transaction == null)
            //{
            //    throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            //}

            //try
            //{
            //    _transactionRefCount--;
            //    if (_transactionRefCount <= 0)
            //    {
            //        ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChanges();
            //        _transaction.Commit();
            //        ReleaseCurrentTransaction();
            //    }
            //}
            //catch
            //{
            //    RollBackTransaction();
            //    throw;
            //}

            _dbContext.ChangeTracker.Context.Database.CommitTransaction();
        }

        public int SaveChanges()
        {
            //try
            //{
            //    if (IsInTransaction)
            //    {
            //        throw new ApplicationException("A transaction is running. Call CommitTransaction instead.");
            //    }

            //    return ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChanges();
            //}
            //catch(Exception ex)
            //{
            //    ;
            //}
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception ex) { }
            return -1;
        }


        public Task<int> SaveChangesAsync()
        {
            //if (IsInTransaction)
            //{
            //    throw new ApplicationException("A transaction is running. Call CommitTransaction instead.");
            //}

            //return  ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChangesAsync();

            return _dbContext.SaveChangesAsync();
        }

        //public int SaveChanges(SaveOptions saveOptions, bool IsAuditEnabled = false)
        //{
        //    if (IsInTransaction)
        //    {
        //        throw new ApplicationException("A transaction is running. Call CommitTransaction instead.");
        //    }

        //    if (IsAuditEnabled)
        //    {
        //        return ((IObjectContextAdapter)_dbContext).ObjectContext.SaveChanges();
        //    }
        //    else
        //    {
        //        return ((IAuditableContext)_dbContext).SaveChanges();

        //    }
        //}

        #region Implementation of IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                return;

            _disposed = true;
        }

        private bool _disposed;
        #endregion

        private void OpenConnection()
        {
            //if (((IObjectContextAdapter)_dbContext).ObjectContext.Connection.State != ConnectionState.Open)
            //{
            //    ((IObjectContextAdapter)_dbContext).ObjectContext.Connection.Open();
            //}

            
        }

        private void ReleaseCurrentTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }







    }
}
