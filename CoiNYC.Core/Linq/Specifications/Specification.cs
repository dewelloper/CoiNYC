using System;
using System.Linq;
using System.Linq.Expressions;
using CoiNYC.Core.Extensions;

namespace CoiNYC.Core.Linq.Specifications
{
    public class Specification<T> : ISpecification<T>
    {   
        public Specification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new Specification<T>(this.Predicate.And(specification.Predicate));
        }

        public Specification<T> And(Expression<Func<T, bool>> predicate)
        {
            return new Specification<T>(this.Predicate.And(predicate));
        }    

        public Specification<T> Or(Specification<T> specification)
        {
            return new Specification<T>(this.Predicate.Or(specification.Predicate));
        }

        public Specification<T> Or(Expression<Func<T, bool>> predicate)
        {
            return new Specification<T>(this.Predicate.Or(predicate));
        }

        public T SatisfyingEntityFrom(IQueryable<T> query)
        {
            return query.Where(Predicate).SingleOrDefault();
        }

        public IQueryable<T> SatisfyingEntitiesFrom(IQueryable<T> query)
        {
            return query.Where(Predicate);
        }

        public Expression<Func<T, bool>> Predicate;
    }
}
