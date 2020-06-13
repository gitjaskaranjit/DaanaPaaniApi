using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> getAll();

        Task<T> getById(int id);

        Task<T> add(T entity);

        Task<T> update(int id, T entity);

        void delete(T entity);
    }
}