using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

/*http://forums.asp.net/p/1580414/3981470.aspx*/
namespace LiteSchool.Library.Extensions.Expressions
{
    public static class OrderByExtension
    {        
        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string memberName, string methodeName)
        {
            ParameterExpression[] typeParams = new ParameterExpression[] { Expression.Parameter(typeof(T), "") };

            System.Reflection.PropertyInfo pi = typeof(T).GetProperty(memberName);

            return (IOrderedQueryable<T>)query.Provider.CreateQuery(
                Expression.Call(
                    typeof(Queryable),
                    methodeName,
                    new Type[] { typeof(T), pi.PropertyType },
                    query.Expression,
                    Expression.Lambda(Expression.Property(typeParams[0], pi), typeParams))
            );
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string memberName)
        {
            return OrderBy<T>(query, memberName, "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string memberName)
        {
            return OrderBy<T>(query, memberName, "OrderByDescending");
        }        
    }
}
