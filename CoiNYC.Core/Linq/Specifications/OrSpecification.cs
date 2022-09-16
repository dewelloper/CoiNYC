using System.Linq;
using CoiNYC.Core.Extensions;

namespace CoiNYC.Core.Linq.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(Specification<T> leftSide, Specification<T> rightSide)
            : base(leftSide, rightSide)
        {
        }        

        public override T SatisfyingEntityFrom(IQueryable<T> query)
        {
            return SatisfyingEntitiesFrom(query).FirstOrDefault();
        }

        public override IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            return query.Where(leftSide.Predicate.Or(rightSide.Predicate));
        }
    }
}
