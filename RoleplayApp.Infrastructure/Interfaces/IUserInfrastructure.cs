using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.Infrastructure.Interfaces
{
    public interface IUserInfrastructure
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(int id);
        public Task<bool> SaveAsync(User user);
        public Task<bool> UpdateAsync(int id, User user);
        public Task<bool> DeleteAsync(int id);
    }
}
