using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi.Repository
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository 
    {
        private readonly DataContext _db;
        public PaymentRepository(DataContext db) : base(db)
        {
            _db = db;
        }
    }
}
