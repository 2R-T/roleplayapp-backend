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
    public class WallCommentsDomain : IWallCommentsDomain
    {
        public readonly IWallCommentsInfrastructure _wallCommentsInfrastructure;
        public WallCommentsDomain(IWallCommentsInfrastructure wallCommentsInfrastructure)
        {
            _wallCommentsInfrastructure = wallCommentsInfrastructure;
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _wallCommentsInfrastructure.DeleteAsync(id);
        }

        public Task<bool> SaveAsync(WallComments wallComments)
        {
            return _wallCommentsInfrastructure.SaveAsync(wallComments);
        }
    }
}
