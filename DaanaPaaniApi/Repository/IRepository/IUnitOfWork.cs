using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IPackageRepository Package { get; }
        IItemRepository Item { get; }
        IOrderRepository Order { get; }
        IDriverRepository Driver { get; }
        ILocationRepository Location { get; }

        Task SaveAsync();
    }
}