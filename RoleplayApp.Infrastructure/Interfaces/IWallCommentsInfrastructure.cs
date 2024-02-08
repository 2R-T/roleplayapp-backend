using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Interfaces
{
    public interface IWallCommentsInfrastructure
    {
        public Task<List<WallComments>> GetAllAsync();
        public Task<WallComments> GetByIdAsync(int id);
        public Task<List<WallComments>> GetBySenderId(int senderId);
        public Task<List<WallComments>> GetByReceiverId(int receiverId);
        public Task<bool> SaveAsync(WallComments wallComments);
        public Task<bool> DeleteAsync(int id);
    }
}
