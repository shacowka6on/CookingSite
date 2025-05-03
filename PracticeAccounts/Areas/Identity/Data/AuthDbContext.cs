using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeAccounts.Areas.Identity.Data;
using PracticeAccounts.Models;

namespace PracticeAccounts.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //builder.Entity<Recipe>().HasData(
        //    new Recipe
        //    {
        //        Id = 1,
        //        Name = "Spageti",
        //        Description = "Spageti description",
        //        PhotoUrlPath = "https://leonardobansko.bg/wp-content/uploads/2020/07/2020-07-27_13h48_32.png",
        //        UserId = "9a9220bd-c2d8-4673-98c6-1460fcd077ca"
        //    }
        //);
        //builder.Entity<ApplicationUser>().HasData(
        //    new ApplicationUser
        //    {
        //        Id = "9a9220bd-c2d8-4673-98c6-1460fcd077ca",
        //        UserName = "admin@site.com",
        //        NormalizedUserName = "ADMIN@SITE.COM",
        //        Email = "admin@site.com",
        //        NormalizedEmail = "ADMIN@SITE.COM",
        //        EmailConfirmed = true,
        //        FirstName = "Admin",
        //        LastName = "User",
        //        PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "SomePassword123!")
        //    }
        //);

        builder.Entity<Feedback>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Recipe>()
            .HasOne(r => r.User)
            .WithMany(u => u.Recipes)
            .HasForeignKey(r => r.UserId);

        builder.Entity<Gallery>()
            .HasOne(g => g.Recipe)
            .WithMany()
            .HasForeignKey(g => g.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
}
