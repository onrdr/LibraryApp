using DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Borrower>()
            .HasIndex(e => e.LibraryBorrowerId)
            .IsUnique();

        modelBuilder.SeedData();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Borrower> Borrowers { get; set; }
}
