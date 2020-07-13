using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _db;
        internal DbSet<T> dbSet;

        public Repository(DataContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public T Add(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
                                         IOrderedQueryable<T>> orderBy = null,
                                         Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                         bool disableTracking = false)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            return query;
        }

        public Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = false)
        {
            IQueryable<T> query = dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }
           Console.WriteLine(query.ToString());
            return query.FirstOrDefaultAsync();
        }
    }
}