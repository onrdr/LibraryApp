using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess.Seeders.EntitySeeders;

public static class BorrowerSeeder
{
    public static ModelBuilder SeedBorrowers(this ModelBuilder modelBuilder)
    {
        var authors = GetBorrowers();

        foreach (var author in authors)
        {
            modelBuilder.Entity<Borrower>().HasData(author);
        }

        return modelBuilder;
    }

    private static List<Borrower> GetBorrowers()
    {
        var authors = new List<Borrower>()
        {
            new()
            {
                Id = Guid.Parse("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                Name = "John Doe",
                LibraryBorrowerId = "a373da2e"
            },
            new()
            {
                Id = Guid.Parse("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                Name = "Jane Doe",
                LibraryBorrowerId = "4ecc1064"
            }
        };

        return authors;
    }
}
