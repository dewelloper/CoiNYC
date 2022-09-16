﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CoiNYC.Core.Extensions
{
    public static class QueryableExtansions
    {
        #region Private expression tree helpers

        private static LambdaExpression GenerateSelector<TEntity>(String propertyName, out Type resultType) //where TEntity : class
        {
            // Create a parameter to pass into the Lambda expression (Entity => Entity.OrderByField).
            var parameter = Expression.Parameter(typeof(TEntity), "Entity");
            //  create the selector part, but support child properties
            PropertyInfo property;
            Expression propertyAccess;
            if (propertyName.Contains('.'))
            {
                // support to be sorted on child fields.
                String[] childProperties = propertyName.Split('.');
                property = typeof(TEntity).GetProperty(childProperties[0], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(TEntity).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            resultType = property.PropertyType;
            // Create the order by expression.
            return Expression.Lambda(propertyAccess, parameter);
        }
        private static MethodCallExpression GenerateMethodCall<TEntity>(IQueryable<TEntity> source, string methodName, String fieldName)// where TEntity : class
        {
            Type type = typeof(TEntity);
            Type selectorResultType;
            LambdaExpression selector = GenerateSelector<TEntity>(fieldName, out selectorResultType);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), methodName,
                            new Type[] { type, selectorResultType },
                            source.Expression, Expression.Quote(selector));
            return resultExp;
        }
        #endregion
        public static IOrderedQueryable<TEntity> Order<TEntity>(this IQueryable<TEntity> source, string fieldName, bool isAscending, bool isMultiOrder = false) //where TEntity : class
        {
            MethodCallExpression resultExp = null;
            if (isMultiOrder)
                resultExp = GenerateMethodCall<TEntity>(source, isAscending ? "ThenBy" : "ThenByDescending", fieldName);
            else
                resultExp = GenerateMethodCall<TEntity>(source, isAscending ? "OrderBy" : "OrderByDescending", fieldName);

            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }

        public static IOrderedQueryable<TEntity> OrderByDescending<TEntity>(this IQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "OrderByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        public static IOrderedQueryable<TEntity> ThenBy<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenBy", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        public static IOrderedQueryable<TEntity> ThenByDescending<TEntity>(this IOrderedQueryable<TEntity> source, string fieldName) where TEntity : class
        {
            MethodCallExpression resultExp = GenerateMethodCall<TEntity>(source, "ThenByDescending", fieldName);
            return source.Provider.CreateQuery<TEntity>(resultExp) as IOrderedQueryable<TEntity>;
        }
        public static IOrderedQueryable<TEntity> OrderUsingSortExpression<TEntity>(this IQueryable<TEntity> source, string sortExpression) where TEntity : class
        {
            String[] orderFields = sortExpression.Split(',');
            IOrderedQueryable<TEntity> result = null;
            for (int currentFieldIndex = 0; currentFieldIndex < orderFields.Length; currentFieldIndex++)
            {
                String[] expressionPart = orderFields[currentFieldIndex].Trim().Split(' ');
                String sortField = expressionPart[0];
                Boolean sortDescending = (expressionPart.Length == 2) && (expressionPart[1].Equals("DESC", StringComparison.OrdinalIgnoreCase));
                if (sortDescending)
                {
                    result = currentFieldIndex == 0 ? source.OrderByDescending(sortField) : result.ThenByDescending(sortField);
                }
                else
                {
                    result = currentFieldIndex == 0 ? source.OrderBy(sortField) : result.ThenBy(sortField);
                }
            }
            return result;
        }
    }

}
