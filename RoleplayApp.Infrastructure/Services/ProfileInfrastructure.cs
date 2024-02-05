using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Services
{
    public class ProfileInfrastructure : IProfileInfrastructure
    {
        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Profile> GetByUsernameAsync(int id)
        {
            
        }

        public async Task<bool> SaveAsync(Profile profile)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, Profile profile)
        {
            throw new NotImplementedException();
        }
    }
}
