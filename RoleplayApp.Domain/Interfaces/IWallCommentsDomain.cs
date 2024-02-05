using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Domain.Interfaces
{
    public interface IWallCommentsDomain
    {
        public Task<bool> SaveAsync(WallComments wallComments);
        public Task<bool> DeleteAsync(int id);
    }
}
