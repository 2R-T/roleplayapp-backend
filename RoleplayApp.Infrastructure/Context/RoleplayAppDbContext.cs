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
        public DbSet<Profile> Profile { get; set; }
        public DbSet<WallComments> WallComments { get; set; }

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
            modelBuilder.Entity<User>().Property(u => u.Phone_number);
            modelBuilder.Entity<User>().Property(u => u.Country_code);  
            modelBuilder.Entity<User>().HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<Profile>(p => p.Id);
            
            modelBuilder.Entity<Profile>().ToTable("profile"); 
            modelBuilder.Entity<Profile>().HasKey(p => p.Id);
            modelBuilder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Profile>().Property(p => p.First_name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Profile>().Property(p => p.Last_name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Profile>().Property(p => p.Username).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Profile>().Property(p => p.Birth_date).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.Created_at).IsRequired().HasDefaultValue(DateOnly.FromDateTime(DateTime.UtcNow));
            modelBuilder.Entity<Profile>().Property(p => p.Biography_script).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.profile_picture).IsRequired();
            modelBuilder.Entity<Profile>().Property(p => p.Biography_updated_at).IsRequired().HasDefaultValue(DateTime.UtcNow);

            modelBuilder.Entity<WallComments>().ToTable("wall_comments");
            modelBuilder.Entity<WallComments>().HasKey(wc => wc.Id);
            modelBuilder.Entity<WallComments>().Property(wc => wc.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<WallComments>().Property(wc => wc.Comment).IsRequired();
            modelBuilder.Entity<WallComments>().Property(wc => wc.Created_at).IsRequired().HasDefaultValue(DateTime.UtcNow);
            modelBuilder.Entity<WallComments>().HasOne(wc => wc.User).WithMany(u => u.WallComments).HasForeignKey(wc => wc.User_id);
            modelBuilder.Entity<WallComments>().HasOne(wc => wc.Profile).WithMany(p => p.WallComments).HasForeignKey(wc => wc.Profile_id);





    }
}
