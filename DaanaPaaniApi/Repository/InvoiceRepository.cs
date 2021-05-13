using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly DataContext _db;
        public InvoiceRepository(DataContext db): base(db)
        {
            _db = db; 
        }

    }
}
