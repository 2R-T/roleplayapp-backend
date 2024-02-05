using Microsoft.EntityFrameworkCore;
using RoleplayApp.Infrastructure.Context;
using RoleplayApp.Infrastructure.Interfaces;
using RoleplayApp.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleplayApp.Infrastructure.Services
{
    public class WallCommentsInfrastructure : IWallCommentsInfrastructure
    {
        private readonly RoleplayAppDbContext _context;
        public WallCommentsInfrastructure(RoleplayAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wallCommentsToDelete = await _context.WallComments.FindAsync(id);
            if (wallCommentsToDelete != null)
            {
                _context.WallComments.Remove(wallCommentsToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<WallComments>> GetAllAsync()
        {
            var wallComments = await _context.WallComments.ToListAsync();
            return wallComments;
        }

        public async Task<List<WallComments>> GetAllCommentsByProfileIdAsync(int profileId)
        {
            var wallComments = await _context.WallComments.Where(w => w.Profile_id == profileId).ToListAsync();
            return wallComments;
        }

        public async Task<WallComments> GetByIdAsync(int id)
        {
            var wallComments = await _context.WallComments.FindAsync(id);
            return wallComments;
        }

        public async Task<bool> SaveAsync(WallComments wallComments)
        {
            await _context.WallComments.AddAsync(wallComments);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
