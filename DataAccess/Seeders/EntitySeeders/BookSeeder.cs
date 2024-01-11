using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess.Seeders.EntitySeeders;

public static class BookSeeder
{
    public static ModelBuilder SeedBooks(this ModelBuilder modelBuilder)
    {
        var books = GetBooks();

        foreach (var book in books)
        {
            modelBuilder.Entity<Book>().HasData(book);
        }

        return modelBuilder;
    }

    private static List<Book> GetBooks()
    {
        var books = new List<Book>()
        {
            new()
            {
                Id = Guid.Parse("84c52f0a-401d-40d2-80a1-281e48d5c17e"),
                Name = "Book 1",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                IsAvailable = false,
                BorrowerId = Guid.Parse("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                ReturnDate = DateTime.Now.AddDays(27),
            },
            new()
            {
                Id = Guid.Parse("db63310e-3ddc-4715-a9cd-1f0cf4b14a59"),
                Name = "Book 2",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("a8305503-a8da-4830-bcec-fa985e594a90")
            },
            new()
            {
                Id = Guid.Parse("5c3a0e12-2bc9-45e1-abb3-c3201c94295e"),
                Name = "Book 3",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("503939b1-a170-4474-aa31-f89f5c878bbb"),
                IsAvailable = false,
                BorrowerId = Guid.Parse("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                ReturnDate = DateTime.Now.AddDays(-7),
            },
            new()
            {
                Id = Guid.Parse("b64f2fee-3829-4b9b-af12-bfee40fde344"),
                Name = "Book 4",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                IsAvailable = false,
                BorrowerId = Guid.Parse("a373da2e-3e3f-4b54-b42e-f088123fa2f0"),
                ReturnDate = DateTime.Now.AddDays(25),
            },
            new()
            {
                Id = Guid.Parse("765d0dac-fe8c-447d-a238-f2d941a919aa"),
                Name = "Book 5",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("a8305503-a8da-4830-bcec-fa985e594a90")
            },
            new()
            {
                Id = Guid.Parse("7f039958-66fc-4b1a-9234-a3775c00cbe6"),
                Name = "Book 6",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659"),
                IsAvailable = false,
                BorrowerId = Guid.Parse("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                ReturnDate = DateTime.Now.AddDays(-1),
            },
            new()
            {
                Id = Guid.Parse("f95b5bbe-daa9-4b45-9db7-dfff0126d384"),
                Name = "Book 7",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659")
            },
            new()
            {
                Id = Guid.Parse("442daaec-0a77-48b2-b236-140fd3636cdb"),
                Name = "Book 8",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("a8305503-a8da-4830-bcec-fa985e594a90")
            },
            new()
            {
                Id = Guid.Parse("094ada91-108c-42d2-876b-a982db803495"),
                Name = "Book 9",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("503939b1-a170-4474-aa31-f89f5c878bbb")
            },
            new()
            {
                Id = Guid.Parse("444e0e9b-51ce-4776-ab84-0031ae083cc4"),
                Name = "Book 10",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659")
            },
            new()
            {
                Id = Guid.Parse("517c37bb-720c-48d5-8e26-8d2ed1e3933a"),
                Name = "Book 11",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("a8305503-a8da-4830-bcec-fa985e594a90"),
                IsAvailable = false,
                BorrowerId = Guid.Parse("4ecc1064-a880-4822-87cc-9c39a224eeaf"),
                ReturnDate = DateTime.Now.AddDays(23),
            },
            new()
            {
                Id = Guid.Parse("3c042ca7-6ebc-4e8c-80c0-cd65f7ebc021"),
                Name = "Book 12",
                ISBN = $"{Guid.NewGuid().ToString()[..8]}",
                ImageUrl = "images\\book\\default.jpg",
                AuthorId = Guid.Parse("e5d7b08b-6c9c-4dbb-99f5-cfe1befa9659")
            },
        };

        return books;
    }
}
