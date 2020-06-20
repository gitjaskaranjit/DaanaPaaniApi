using DaanaPaaniApi.Model;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.infrastructure
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options,
                                         ISieveCustomFilterMethods customFilterMethods,
                                         ISieveCustomSortMethods customSortMethods) : base(options,
                                                                                           customSortMethods,
                                                                                           customFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Customer>(p => p.Address.StreetName)
                .CanFilter()
                .CanSort();
            mapper.Property<Customer>(c => c.Address.AddressType)
                    .CanFilter()
                    .CanSort();
            mapper.Property<Customer>(c => c.Address.City)
                   .CanFilter()
                   .CanSort();
            return base.MapProperties(mapper);
        }
    }
}