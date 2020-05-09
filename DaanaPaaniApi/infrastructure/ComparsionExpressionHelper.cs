using DaanaPaaniApi.DTOs;
using LandonApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class ComparsionExpressionHelper
    {
        public static Expression getComparsion(Expression left, string op, ConstantExpression right)
        {

            switch (op)
            {
                case "gt": return Expression.GreaterThan(left, right);
                case "gte": return Expression.GreaterThanOrEqual(left, right);
                case "lt": return Expression.LessThan(left, right);
                case "lte": return Expression.LessThanOrEqual(left, right);
                case "eq": return Expression.Equal(left, right);

                default: throw new ArgumentException($"Invalid operator '{op}'");
            }
        }
        public static ComparsionTerm getParams(ParameterExpression pe, PropertyInfo propertyInfo, SearchTerm term)
        {
            switch (propertyInfo.PropertyType.Name)
            {
                case "String":
                    {
                        return new ComparsionTerm
                        {
                            left = Expression.Call(ExpressionHelper.GetPropertyExpression(pe, propertyInfo), typeof(string).GetMethod("ToLower", Type.EmptyTypes)),
                            right = Expression.Constant(term.Value.ToLower())
                        };
                    }
                case "DateTime":
                    {
                        return new ComparsionTerm
                        {
                            left = ExpressionHelper.GetPropertyExpression(pe, propertyInfo) as Expression,
                            right = Expression.Constant(DateTime.Parse(term.Value.ToString()))
                        };

                    }
                case "Int32":
                    {
                        return new ComparsionTerm
                        {
                            left = ExpressionHelper.GetPropertyExpression(pe, propertyInfo) as Expression,
                            right = Expression.Constant(Int32.Parse(term.Value.ToString()))
                        };
                    }
                case "Boolean":
                    {
                        return new ComparsionTerm
                        {
                            left = ExpressionHelper.GetPropertyExpression(pe, propertyInfo) as Expression,
                            right = Expression.Constant(bool.Parse(term.Value.ToString()))
                        };
                    }
                default: throw new ArgumentException($"invalid type");

            }

        }

    }
}
