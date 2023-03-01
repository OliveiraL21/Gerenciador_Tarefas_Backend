using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace UserApplication.Context
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        DbSet<Usuario> usuarios { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext>options) : base (options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            CustomIdentityUser  admin = new CustomIdentityUser()
            {
                Id = 99999,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin",
                NormalizedEmail = "admin",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = "d1f13107-9c43-4221-926d-6d0bdcf012b6",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            PasswordHasher<CustomIdentityUser> hasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123@!");

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                    new IdentityRole<int>
                    {
                        Id = 99999,
                        Name = "admin",
                        NormalizedName = "ADMIN",
                    }
                );

            builder.Entity<IdentityRole<int>>().HasData(
              new IdentityRole<int>
              {
                  Id = 99997,
                  Name = "regular",
                  NormalizedName = "REGULAR",
              }
          );

            builder.Entity<IdentityUserRole<int>>().HasData(
                    new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
                );
        }
    }
}
