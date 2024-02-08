using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Identity;

namespace DataAccess.Seeders.IdentitySeeders;

public static class AppUserSeeder
{
    public static ModelBuilder SeedAppUsers(this ModelBuilder modelBuilder)
    {
        var appUsers = GetAppUsers();        

        foreach (var appUser in appUsers)
        {
            modelBuilder.Entity<AppUser>().HasData(appUser);
        }

        return modelBuilder;
    }

    private static List<AppUser> GetAppUsers()
    {
        var users = new List<AppUser>
        {
            new()
            {
                Id = Guid.Parse("3e8fb682-ddad-4e8d-855a-35117415c2df"),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@test.com",
                NormalizedEmail = "ADMIN@TEST.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("N"),
                ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            }
        };

        CreatePasswordForAllUsers(users);

        return users;
    }

    private static void CreatePasswordForAllUsers(List<AppUser> users)
    {
        foreach (var user in users)
        {
            var password = new PasswordHasher<AppUser>();
            var hashed = password.HashPassword(user, $"{user.UserName}1*");
            user.PasswordHash = hashed;
        }
    }
}
