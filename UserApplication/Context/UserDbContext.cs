using Domain.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UserApplication.Context
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        DbSet<Usuario> usuarios { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext>options) : base (options) 
        {

        }
    }
}
