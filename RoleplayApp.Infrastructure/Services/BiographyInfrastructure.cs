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
    public class BiographyInfrastructure : IBiographyInfrastructure
    {
        private readonly RoleplayAppDbContext _context;
        public BiographyInfrastructure(RoleplayAppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var biographyToDelete = await _context.Biography.FindAsync(id);
            if (biographyToDelete != null)
            {
                _context.Biography.Remove(biographyToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Biography>> GetAllAsync()
        {
            var biography = await _context.Biography.ToListAsync();
            return biography;
        }

        public async Task<Biography> GetByIdAsync(int id)
        {
            var biography = await _context.Biography.FindAsync(id);
            return biography;

        }

        public async Task<bool> SaveAsync(Biography biography)
        {
            await _context.Biography.AddAsync(biography);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(int id, Biography biography)
        {
            var biographyToUpdate = await _context.Biography.FindAsync(id);
            if (biographyToUpdate != null)
            {
                biographyToUpdate.Biography_script = biography.Biography_script;
                biographyToUpdate.Biography_updated_at = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
