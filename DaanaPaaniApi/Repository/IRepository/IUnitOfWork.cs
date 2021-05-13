using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        IItemRepository Item { get; }
        IOrderRepository Order { get; }
        IDriverRepository Driver { get; }
        ILocationRepository Location { get; }
        IInvoiceRepository Invoice { get;  }
        IPaymentRepository Payment { get;  }
        Task SaveAsync();
    }
}