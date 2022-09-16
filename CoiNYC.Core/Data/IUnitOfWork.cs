using System;
using System.Data;
using System.Threading.Tasks;

namespace CoiNYC.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool IsInTransaction { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void BeginTransaction();

        void BeginTransaction(IsolationLevel isolationLevel);

        void RollBackTransaction();

        void CommitTransaction();
    }
}
