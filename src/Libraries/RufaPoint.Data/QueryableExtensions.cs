using System;
using System.Linq;
using System.Linq.Expressions;

namespace RufaPoint.Data 
{
    /// <summary>
    /// Queryable extensions
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Include
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="queryable">Queryable</param>
        /// <param name="includeProperties">A list of properties to include</param>
        /// <returns>New queryable</returns>
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> queryable,
            params Expression<Func<T, object>>[] includeProperties)
        {
            if (queryable == null)
                throw new ArgumentNullException(nameof(queryable));

           //Pekmez foreach (var includeProperty in includeProperties)
               //Pekmez queryable = queryable.Include(includeProperty);

            return queryable;
        }

    }
}