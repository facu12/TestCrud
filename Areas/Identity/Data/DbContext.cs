using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestCrud.Areas.Identity.Data;

namespace TestCrud.Data;

public class DbContext : IdentityDbContext<User>
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.Entity<User>()
            .ToTable("AspNetUsers");
        builder.Entity<User>().Property(x => x.UserName).IsRequired(false);
        builder.Entity<User>().Property(x => x.NormalizedUserName).IsRequired(false);
        builder.Entity<User>().Property(x => x.Email).IsRequired(false);
        builder.Entity<User>().Property(x => x.NormalizedEmail).IsRequired(false);
        builder.Entity<User>().Property(x => x.PasswordHash).IsRequired(false);
        builder.Entity<User>().Property(x => x.SecurityStamp).IsRequired(false);
        builder.Entity<User>().Property(x => x.ConcurrencyStamp).IsRequired(false);
        builder.Entity<User>().Property(x => x.PhoneNumber).IsRequired(false);
        builder.Entity<User>().Property(x => x.LockoutEnd).IsRequired(false);

        builder.Entity<User>()
            .HasData(
                new User
                {
                    Email = "admin@admin.com",
                    NormalizedEmail = "admin@admin.com".ToUpper(),
                    PasswordHash = "AQAAAAEAACcQAAAAEKv0EIjfkGuaTKbyL9pK2Ds4BRilUcnVwzh8CLqIHkRUf39c9sFujBpcQdMaBzQ7bw=="
                }
            );
    }
}
