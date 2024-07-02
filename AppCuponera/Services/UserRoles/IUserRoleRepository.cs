using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCuponera.Models;

namespace AppCuponera.Services.UserRoles
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAll();
        UserRole GetById(int id);
        void Add(UserRole userRole);
        void Update(UserRole userRole);
        void Delete(int id);
    }
}