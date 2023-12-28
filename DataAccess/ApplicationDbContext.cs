using DataAccess.Seeders;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedData();
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}
