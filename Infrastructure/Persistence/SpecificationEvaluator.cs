using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery ,ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;

            if (specifications.Criteria is not null)
            {
                query = query.Where(specifications.Criteria);

                if (specifications.OrderByDescending is not null)
                {
                    query = query.OrderByDescending(specifications.OrderByDescending);
                }
                else if (specifications.OrderBy is not null)
                {
                    query = query.OrderBy(specifications.OrderBy);
                }
            }

            query = specifications.IncludeExpressions.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
           
            if (specifications.IsPagination)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            return query;
        }
    }
}
