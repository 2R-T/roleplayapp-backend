using Microsoft.EntityFrameworkCore;
using RoleplayApp.Infrastructure.Context;
using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;

namespace RoleplayApp.Infrastructure.Services
{
    public class ProfileInfrastructure : IProfileInfrastructure
    {
        public readonly RoleplayAppDbContext _context;

        public ProfileInfrastructure(RoleplayAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profileToDelete = await _context.Profile.FirstOrDefaultAsync(p => p.Id == id);  
            if (profileToDelete != null)
            {
                _context.Profile.Remove(profileToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Profile>> GetAllAsync()
        {
            var profiles = await _context.Profile.ToListAsync();
            return profiles;

        }

        public async Task<List<Profile>> GetByUsernameAsync(string username)
        {
            var profiles = await _context.Profile.Where(p => p.Username == username).ToListAsync();
            return profiles;
        }

        public async Task<bool> SaveAsync(Profile profile)
        {
            await _context.Profile.AddAsync(profile);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, Profile profile)
        {
            var profileToUpdate = await _context.Profile.FirstOrDefaultAsync(p => p.Id == id);
            if (profileToUpdate != null)
            {
                profileToUpdate.Username = profile.Username;
                profileToUpdate.Profile_picture = profile.Profile_picture;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
