using Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Concrete;

public class Book : IBaseEntity
{
    public Book()
    {
        Id = Guid.NewGuid();
        IsAvailable = true;
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string ISBN { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    public DateTimeOffset? ReturnDate { get; set; }
    public string? ImageUrl { get; set; }

    // Navigation Properties
    [Required]
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }

    public Guid? BorrowerId { get; set; }
    public Borrower? Borrower { get; set; }
}
