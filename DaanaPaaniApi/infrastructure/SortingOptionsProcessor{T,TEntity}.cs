using DaanaPaaniApi.DTOs;
using LandonApi.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class SortingOptionsProcessor<T,TEntity>
    {
        private readonly string[] _orderBy;
        public SortingOptionsProcessor(string[] orderBy)
        {
            _orderBy = orderBy;
        }

        public IEnumerable<SortTerm> GetAllTerms()
        {
            if (_orderBy == null) yield break;
            foreach (var term in _orderBy) {
                var token = term.Split(' ');
                if (token.Length == 0)
                {
                    yield return new SortTerm { Name = term };
                }
                var descending = token.Length > 1 && token[1].Equals("desc", StringComparison.OrdinalIgnoreCase);
                yield return new SortTerm
                {
                    Name = token[0],
                    Descending = descending
                };
            }
        }
        private static IEnumerable<SortTerm> GetTermsFromModel()
        {
        return    typeof(T).GetTypeInfo()
                        .DeclaredProperties
                        .Where(p => p.GetCustomAttributes<SortableAttribute>().Any())
                        .Select(p => new SortTerm { Name = p.Name });
        }
        public IEnumerable<SortTerm> GetValidTerms()
        {
            var queryTerms = GetAllTerms().ToArray();
            if (!queryTerms.Any())  yield break;

            var declaredTerms = GetTermsFromModel();

            foreach (var term in queryTerms)
            {
                var declaredTerm = declaredTerms.SingleOrDefault(x => x.Name.Equals(term.Name, StringComparison.OrdinalIgnoreCase));
                if (declaredTerm == null) continue;
                yield return new SortTerm
                {
                    Name = declaredTerm.Name,
                    Descending = term.Descending
                };
            }

        }
        public IQueryable<TEntity> Apply(IQueryable<TEntity> query)
        {
            var terms = GetValidTerms().ToArray() ;
            if (!terms.Any()) return query;
            var modifiedQuery = query;
            var useThenBy = false;

            foreach (var term in terms)
            {
                var propertyInfo = ExpressionHelper.GetPropertyInfo<TEntity>(term.Name); // property
               var parameterExpression = ExpressionHelper.Parameter<TEntity>(); // x
                                                                                // propertyInfo.PropertyType;
                                                                                //x=>x.property
                var key = ExpressionHelper.GetPropertyExpression(parameterExpression,propertyInfo);//x.property

                var keySelector = ExpressionHelper.GetLambda(typeof(TEntity), propertyInfo.PropertyType, parameterExpression, key);

                modifiedQuery = ExpressionHelper.CallOrderByOrThenBy(modifiedQuery,useThenBy,term.Descending,propertyInfo.PropertyType,keySelector);

                useThenBy = true;

                //    var expression = Expression.Lambda(key,parameterExpression); //x=>x.property

                //    //  var keySelector = Expression.Lambda<Func<TEntity,object>>(key, new ParameterExpression[] { parameterExpression });
                //    var methodName = "OrderBy";
                //    if (useThenBy) methodName = "ThenBy";
                //    if (term.Descending) methodName += "Descending";
                //    var types = new Type[] { typeof(TEntity), propertyInfo.PropertyType };

                //    finalExpression = Expression.Call(typeof(Queryable),methodName,types,modifiedQuery.Expression,expression);
                //    useThenBy = true;
            }

            return modifiedQuery;
        }
    }
}
