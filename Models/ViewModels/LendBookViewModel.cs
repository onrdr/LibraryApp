using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class LendBookViewModel
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Borrower's Library Id must be exactly 8 characters.")]
    [Display(Name = "Borrower's Library Id")]
    public string BorrowerLibraryId { get; set; }

    [Required]
    [Display(Name = "Return Date")]
    public DateTimeOffset ReturnDate { get; set; }

    public string ImageUrl { get; set; }
}
