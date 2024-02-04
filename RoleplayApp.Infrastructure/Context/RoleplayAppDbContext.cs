using Microsoft.EntityFrameworkCore;
using RoleplayApp.Infrastructure.Models;
using System.Reflection.Metadata;

namespace RoleplayApp.Infrastructure.Context
{
    public class RoleplayAppDbContext : DbContext
    {
        public RoleplayAppDbContext() { }
        public RoleplayAppDbContext(DbContextOptions<RoleplayAppDbContext> options) : base(options){ }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=admin;Database=RoleplayApp", serverVersion);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);

        }
    }
}
