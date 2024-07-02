using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;

namespace AppCuponera.Services.Purchases
{
    public interface IPurchaseRepository
    {
        IEnumerable<Purchase> GetAll();
        Purchase GetById(int id);
        void Add(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int id);
    }
}