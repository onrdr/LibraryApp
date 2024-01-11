using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess.Seeders.EntitySeeders;

public static class AuthorSeeder
{
    public static ModelBuilder SeedAuthors(this ModelBuilder modelBuilder)
    {
        var authors = GetAuthors();

        foreach (var author in authors)
        {
            modelBuilder.Entity<Author>().HasData(author);
        }

        return modelBuilder;
    }

    private static List<Author> GetAuthors()
    {
        var authors = new List<Author>()
        {
            new()
            {
                Id = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                Name = "Author 1"
            },
            new()
            {
                Id = Guid.Parse("a8305503-a8da-4830-bcec-fa985e594a90"),
                Name = "Author 2"
            },
            new()
            {
                Id = Guid.Parse("503939b1-a170-4474-aa31-f89f5c878bbb"),
                Name = "Author 3"
            },
        };

        return authors;
    }
}
