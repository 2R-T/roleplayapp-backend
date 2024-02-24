using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Interfaces
{
    public interface IProfileInfrastructure
    {
        public Task<List<Profile>> GetByUsernameAsync(string username);
        public Task<List<Profile>> GetAllAsync();
        public Task<bool> SaveAsync(Profile profile);
        public Task<bool> UpdateAsync(int id, Profile profile);
        public Task<bool> DeleteAsync(int id);

    }
}
