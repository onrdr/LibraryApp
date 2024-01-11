using DataAccess.Seeders.EntitySeeders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Seeders;

public static class DataSeeder
{
    public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .SeedAuthors()
            .SeedBorrowers()
            .SeedBooks();

        return modelBuilder;
    }
}
