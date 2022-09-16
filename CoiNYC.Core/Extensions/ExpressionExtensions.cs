using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CoiNYC.Core.Helpers;

namespace CoiNYC.Core.Extensions
{

    public static class ExpressionExtensions
    {

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {

            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);

        }


        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }


        public static string MemberName<T, V>(this Expression<Func<T, V>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.Name;
        }

        public static A GetAttribute<T, V, A>(this Expression<Func<T, V>> expression)
            where A: Attribute
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Expression must be a member expression");

            return memberExpression.Member.First<A>();
        }

        public static MemberInfo GetMemberInfo<T, M>(this Expression<Func<T, M>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member != null)
                return member.Member;

            throw new ArgumentException("Expression is not a member access", "expression");
        }
    }
}
