using DaanaPaaniApi.Model;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class SieveCustomFilterMethods : ISieveCustomFilterMethods
    {
        //TODO: Fix isActive filter
        public IQueryable<Customer> isActive(IQueryable<Customer> source, string op, string[] values) // The method is given the {Operator} & {Value}
        {
            if (op == "==" && values.Length > 0)
            {
                if (values[0] == "true")
                {
                    return source.Where(p => p.Order.Where(o => o.EndDate > DateTime.Now).Any());
                }
                else
                {
                    return source.Where(p => p.Order.Where(o => o.EndDate < DateTime.Now).Any() || !p.Order.Any());
                }
            }
            else
            {
                return source;
            }
        }
    }
}