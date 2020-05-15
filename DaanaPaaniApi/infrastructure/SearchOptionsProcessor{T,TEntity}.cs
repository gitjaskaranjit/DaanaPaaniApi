using DaanaPaaniApi.DTOs;
using LandonApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DaanaPaaniApi.infrastructure
{
    public class SearchOptionsProcessor<T, TEntity>
    {
        private readonly string[] _search;

        public SearchOptionsProcessor(String[] search)
        {
            _search = search;
        }

        public IEnumerable<SearchTerm> GetAllTerms()
        {
            if (_search == null) yield break;
            foreach (var expression in _search)
            {
                if (string.IsNullOrEmpty(expression)) continue;

                var tokens = expression.Split(' ');
                if (tokens.Length == 0)
                {
                    yield return new SearchTerm
                    {
                        ValidSyntax = false,
                        Name = expression
                    };
                    continue;
                }
                if (tokens.Length < 3)
                {
                    yield return new SearchTerm
                    {
                        ValidSyntax = false,
                        Name = tokens[0]
                    };
                    continue;
                }
                yield return new SearchTerm
                {
                    ValidSyntax = true,
                    Name = tokens[0],
                    Operator = tokens[1],
                    Value = string.Join(" ", tokens.Skip(2))
                };
            }
        }

        public IEnumerable<SearchTerm> GetValidTerms()
        {
            var terms = GetAllTerms().Where(x => x.ValidSyntax).ToArray();
            if (!terms.Any()) yield break;

            var declaredTerms = GetTermsFromModel();
            foreach (var term in terms)
            {
                var declaredTerm = declaredTerms.SingleOrDefault(x => x.Name.Equals(term.Name, StringComparison.OrdinalIgnoreCase));
                if (declaredTerm == null) continue;
                yield return new SearchTerm
                {
                    ValidSyntax = term.ValidSyntax,
                    Name = declaredTerm.Name,
                    Operator = term.Operator,
                    Value = term.Value
                };
            }
        }

        public IEnumerable<SearchTerm> GetTermsFromModel()
        {
            return typeof(T).GetTypeInfo()
                        .DeclaredProperties
                        .Where(p => p.GetCustomAttributes<Searchable>().Any())
                        .Select(p => new SearchTerm { Name = p.Name });
        }

        public IQueryable<TEntity> Apply(IQueryable<TEntity> query)
        {
            var terms = GetValidTerms().ToArray();
            if (!terms.Any()) return query;
            var modifiedQuery = query;

            foreach (var term in terms)
            {
                var propertyInfo = ExpressionHelper.GetPropertyInfo<TEntity>(term.Name);
                var parameterExpressiom = ExpressionHelper.Parameter<TEntity>();
                var parm = ComparsionExpressionHelper.getParams(parameterExpressiom, propertyInfo, term);
                var comparsion = ComparsionExpressionHelper.getComparsion(parm.left, term.Operator, parm.right);
                var lamba = ExpressionHelper.GetLambda<TEntity, bool>(parameterExpressiom, comparsion);
                modifiedQuery = ExpressionHelper.CallWhere(modifiedQuery, lamba);
            }
            return modifiedQuery;
        }
    }
}