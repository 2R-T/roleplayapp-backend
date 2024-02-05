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
    public class BiographyDomain : IBiographyDomain
    {
        private readonly IBiographyInfrastructure _biographyInfrastructure;
        public BiographyDomain(IBiographyInfrastructure biographyInfrastructure)
        {
            _biographyInfrastructure = biographyInfrastructure;
        }

        public Task<bool> DeleteAsync(int id)
        { 
            return _biographyInfrastructure.DeleteAsync(id);
        }

        public Task<bool> SaveAsync(Biography biography)
        {
            return _biographyInfrastructure.SaveAsync(biography);
        }

        public Task<bool> UpdateAsync(int id, Biography biography)
        {
            return  _biographyInfrastructure.UpdateAsync(id, biography);
        }
    }
}
