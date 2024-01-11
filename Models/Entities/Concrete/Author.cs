using Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities.Concrete;

public class Author : IBaseEntity
{
    public Author()
    {
        Id = Guid.NewGuid();
        Books = new List<Book>();
    }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation Properties
    public IEnumerable<Book> Books { get; set; }
}