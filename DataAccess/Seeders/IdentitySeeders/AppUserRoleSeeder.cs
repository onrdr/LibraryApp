using Microsoft.EntityFrameworkCore;
using Models.Identity;

namespace DataAccess.Seeders.IdentitySeeders;

public static class AppUserRoleSeeder
{
    public static ModelBuilder SeedAppUserRoles(this ModelBuilder modelBuilder)
    {
        var appUserRoles = GetAppUserRoles();

        foreach (var userRole in appUserRoles)
        {
            modelBuilder.Entity<AppUserRole>().HasData(userRole);
        }

        return modelBuilder;
    }

    public static List<AppUserRole> GetAppUserRoles()
    {
        var appUserRoles = new List<AppUserRole>()
        {
            // Admin
            new()
            {
               UserId = Guid.Parse("3e8fb682-ddad-4e8d-855a-35117415c2df"),
               RoleId = Guid.Parse("2f514e34-8a22-4e36-aefc-752ba3aa0b34"),
            }
        };

        return appUserRoles;
    }
}

