using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Domain.Interfaces
{
    public interface IProfileDomain
    {
        public Task<bool> SaveAsync(Profile profile);
        public Task<bool> UpdateAsync(int id, Profile profile);
        public Task<bool> DeleteAsync(int id);

    }
}
