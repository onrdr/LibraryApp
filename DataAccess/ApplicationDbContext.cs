using DataAccess.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;
using Models.Identity;

namespace DataAccess;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) 
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
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
