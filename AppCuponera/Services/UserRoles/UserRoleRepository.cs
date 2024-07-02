using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Data;
using AppCuponera.Models;

namespace AppCuponera.Services.UserRoles
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public readonly BaseContext _context;
        public UserRoleRepository(BaseContext context)
        {
            _context = context;
        }
        public void Add(UserRole userRole)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserRole userRole)
        {
            throw new NotImplementedException();
        }
    }
}