using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;

namespace AppCuponera.Services.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public readonly BaseContext _context;
        public PurchaseRepository(BaseContext context)
        {
            _context = context;
        }
        
        public void Add(Purchase purchase)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Purchase> GetAll()
        {
            throw new NotImplementedException();
        }

        public Purchase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}