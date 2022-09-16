using System;
using Microsoft.EntityFrameworkCore;

namespace CoiNYC.Core.Data
{
    public interface IDbContextBuilder<T> where T : DbContext
    {
        T BuildDbContext();
    }
}
