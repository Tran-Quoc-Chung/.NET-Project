using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<StatusActive> StatusActives { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserToRole> UserToRoles { get; set; }
        public DbSet<RoleToPermission> RoleToPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusActive>().ToTable("StatusActive").HasKey(key=>key.StatusID);
            modelBuilder.Entity<User>().ToTable("User").HasKey(key=>key.UserID);
            modelBuilder.Entity<Role>().ToTable("Role").HasKey(key=>key.RoleID);
            modelBuilder.Entity<Permission>().ToTable("Permission").HasKey(key=>key.PermissionID);
            modelBuilder.Entity<UserToRole>().ToTable("UserToRole").HasKey(table=>new{
                table.RoleID,table.UserID
            });
            modelBuilder.Entity<RoleToPermission>().ToTable("RoleToPermission").HasKey(table=>new{
                table.RoleID, table.PermissionID
            });  
        }
    }
}