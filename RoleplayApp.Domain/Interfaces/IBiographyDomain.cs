using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Domain.Interfaces
{
    public interface IBiographyDomain
    {
        public Task<bool> SaveAsync(Biography biography);
        public Task<bool> UpdateAsync(int id, Biography biography);
        public Task<bool> DeleteAsync(int id);
    }
}
