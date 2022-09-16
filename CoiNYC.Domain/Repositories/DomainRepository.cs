using CoiNYC.Core.Data;

namespace CoiNYC.Domain.Repositories
{
    internal interface IDomainRepository : IRepository
    {
        DomainDbContext Context { get; }
    }

    public class DomainRepository : GenericRepository, IDomainRepository
    {
        public DomainRepository(DomainDbContext context)
            : base(context)
        {
        }

        public DomainDbContext Context { get { return (DomainDbContext)this.DbContext; } }
    }
}
