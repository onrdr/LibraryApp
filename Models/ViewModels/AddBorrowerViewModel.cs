using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class AddBorrowerViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string LibraryBorrowerId { get; set; }
}
