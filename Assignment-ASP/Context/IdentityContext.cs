using Assignment_ASP.Models.Entitys;
using Assignment_ASP.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_ASP.Context;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {

    }

    public DbSet<AdressEntity> AspNetAdresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
            );

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
    );
    }
}
