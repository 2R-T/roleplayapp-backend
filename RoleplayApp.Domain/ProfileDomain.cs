using RoleplayApp.Domain.Interfaces;
using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Domain
{
    public class ProfileDomain : IProfileDomain
    {
        public readonly IProfileInfrastructure _profileInfrastructure;
        public ProfileDomain(IProfileInfrastructure profileInfrastructure)
        {
            _profileInfrastructure = profileInfrastructure;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _profileInfrastructure.DeleteAsync(id);
        }

        public async Task<bool> SaveAsync(Profile profile)
        {
            return await _profileInfrastructure.SaveAsync(profile);
        }

        public async Task<bool> UpdateAsync(int id, Profile profile)
        {
           return await _profileInfrastructure.UpdateAsync(id, profile);
        }
    }
}
