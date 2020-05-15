﻿using DaanaPaaniApi.Model;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface ICustomerService
    {
        IQueryable<Customer> getAll();

        Task<Customer> getById(int id);

        Task<Customer> add(Customer customer);

        Task<Customer> update(int id, Customer customer);

        void delete(Customer customer);
    }
}