using System.Linq;

namespace CoiNYC.Core.Linq.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        protected readonly Specification<T> leftSide;
        protected readonly Specification<T> rightSide;

        public CompositeSpecification(Specification<T> leftSide, Specification<T> rightSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
        }

        public abstract T SatisfyingEntityFrom(IQueryable<T> query);

        public abstract IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query);
    }
}
