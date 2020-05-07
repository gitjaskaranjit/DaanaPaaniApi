using DaanaPaaniApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface ICustomerService
    {

        IQueryable<Customer> getAll(PagingOptions pagingOptions);
        Task<Customer> getById(int id);
        Task<Customer> add(Customer customer);
        Task<Customer> update(int id, Customer customer);
        void delete(Customer customer);
    }
}
