using System.Linq;

namespace CoiNYC.Core.Linq.Specifications
{
    public interface ISpecification<T>
    {
        T SatisfyingEntityFrom(IQueryable<T> query);

        IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query);
    }
}
