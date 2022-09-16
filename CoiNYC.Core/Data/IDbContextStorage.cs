using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoiNYC.Core.Data
{
    public interface IDbContextStorage
    {
        DbContext GetDbContextForKey(string key);
        void SetDbContextForKey(string key, DbContext objectContext);
        IEnumerable<DbContext> GetAllDbContexts();
    }
}
