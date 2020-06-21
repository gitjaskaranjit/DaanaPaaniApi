using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        void Delete(int id);

        IQueryable<T> GetAllAsync(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                             bool disableTracking = false
           );

        Task<T> GetFirstOrDefault(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
           bool disableTracking = false
           );
    }
}