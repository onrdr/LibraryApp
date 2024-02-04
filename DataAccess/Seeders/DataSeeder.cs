using DataAccess.Seeders.EntitySeeders;
using DataAccess.Seeders.IdentitySeeders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders;

public static class DataSeeder
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .SeedAuthors()
            .SeedBorrowers()
            .SeedBooks()
            .SeedRoles()
            .SeedAppUsers()
            .SeedAppUserRoles();

        return modelBuilder;
    }
}
