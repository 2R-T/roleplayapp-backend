using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Domain.Interfaces
{
    public interface IUserDomain
    {
        public Task<bool> SaveAsync(User user);
        public Task<bool> UpdateAsync(int id, User user);
        public Task<bool> DeleteAsync(int id);
    }
}
