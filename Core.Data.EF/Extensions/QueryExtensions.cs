using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Core.Data.EF.Extensions
{
    public static class QueryExtensions
    {
        // Where any search predicates are true.
        public static IQueryable<T> WhereAny<T>(this IQueryable<T> q, params Expression<Func<T, bool>>[] predicates)
        {
            var orPredicate = PredicateBuilder.New<T>();
            foreach (var predicate in predicates)
            {
                orPredicate = orPredicate.Or(predicate);
            }
            return q.AsExpandable().Where(orPredicate);
        }
    }
}
