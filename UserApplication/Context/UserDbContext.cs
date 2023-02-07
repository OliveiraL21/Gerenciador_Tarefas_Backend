using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace UserApplication.Context
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        DbSet<Usuario> usuarios { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext>options) : base (options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            IdentityUser<int> admin = new IdentityUser<int>
            {
                Id = 99999,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin",
                NormalizedEmail = "admin",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123@!");

            builder.Entity<IdentityUser<int>>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                    new IdentityRole<int>
                    {
                        Id = 99999,
                        Name = "admin",
                        NormalizedName = "admin",
                    }
                );

            builder.Entity<IdentityRole<int>>().HasData(
              new IdentityRole<int>
              {
                  Id = 99997,
                  Name = "regular",
                  NormalizedName = "regular",
              }
          );

            builder.Entity<IdentityUserRole<int>>().HasData(
                    new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
                );
        }
    }
}
