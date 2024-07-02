using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;

namespace AppCuponera.Services.Roles
{
    public class RoleRepository : IRoleRepository
    {
        public readonly BaseContext _context;
        public RoleRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}