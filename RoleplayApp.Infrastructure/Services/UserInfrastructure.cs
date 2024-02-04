using Microsoft.EntityFrameworkCore;
using RoleplayApp.Infrastructure.Context;
using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.Infrastructure.Services
{
    public class UserInfrastructure : IUserInfrastructure
    {
        public readonly RoleplayAppDbContext _context;

        public UserInfrastructure(RoleplayAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var userToDelete = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (userToDelete != null)
            {
                _context.User.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<bool> SaveAsync(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> UpdateAsync(int id, User user)
        {
            var userToUpdate = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (userToUpdate != null)
            {
                userToUpdate.Email = user.Email;
                userToUpdate.Password = user.Password;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
