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
    public class UserDomain : IUserDomain
    {
        private readonly IUserInfrastructure _userInfrastructure;
        public UserDomain(IUserInfrastructure userInfrastructure)
        {
            _userInfrastructure = userInfrastructure;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await _userInfrastructure.DeleteAsync(id);
        }

        public async Task<bool> SaveAsync(User user)
        {
            return await _userInfrastructure.SaveAsync(user);
        }

        public async Task<bool> UpdateAsync(int id, User user)
        {
            return await _userInfrastructure.UpdateAsync(id, user);
        }
    }
}
