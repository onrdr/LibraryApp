using Core.Constants;
using Microsoft.EntityFrameworkCore;
using Models.Identity;

namespace DataAccess.Seeders.IdentitySeeders;

public static class RoleSeeder
{
    public static ModelBuilder SeedRoles(this ModelBuilder modelBuilder)
    {
        var roles = GetRoles();

        foreach (var role in roles)
        {
            modelBuilder.Entity<AppRole>().HasData(role);
        }

        return modelBuilder;
    }
    public static List<AppRole> GetRoles()
    {
        var roles = new List<AppRole>()
        {
            new()
            {
                Id = Guid.Parse("2f514e34-8a22-4e36-aefc-752ba3aa0b34"),
                Name = CustomRoles.Admin,
                NormalizedName = CustomRoles.Admin.ToUpper()
            }
        };

        return roles;
    }
}
