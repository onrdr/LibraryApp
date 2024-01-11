using Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Concrete;

public class Borrower : IBaseEntity
{
    public Borrower()
    {
        Id = Guid.NewGuid();
        BorrowedBooks =  [];
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(8)]
    public string LibraryBorrowerId { get; set; }

    // Navigation Properties
    public List<Book> BorrowedBooks { get; set; }
}
