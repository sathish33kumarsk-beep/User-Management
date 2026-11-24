using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using User_Management.Models;

namespace User_Management.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
           DbContextOptions<AppDbContext> options)
                : base(options)
        {

        }
        
            public DbSet<User> Users { get; set; }

            public DbSet<Role> Roles { get; set; }

            protected override void OnModelCreating(
                ModelBuilder modelBuilder ) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1,
                    RoleName = "Admin",
                    Active = 1
                },
                new Role
                {
                    RoleID = 2,
                    RoleName = "Manager",
                    Active = 1
                },
                new Role
                {
                    RoleID = 3,
                    RoleName = "Employee",
                    Active = 1
                }
                );

        }


}

}
