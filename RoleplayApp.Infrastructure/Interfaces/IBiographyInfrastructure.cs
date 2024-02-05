using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Interfaces
{
    public interface IBiographyInfrastructure
    {
        public Task<Biography> GetByIdAsync(int id);
        public Task<bool> SaveAsync(Biography biography);
        public Task<bool> UpdateAsync(int id, Biography biography);
        public Task<bool> DeleteAsync(int id);
    }
}
