using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class LendBookViewModel
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Borrowed By")]
    public string BorrowedBy { get; set; }

    [Required]
    [Display(Name = "Return Date")]
    public DateTimeOffset ReturnDate { get; set; }

    public string ImageUrl { get; set; }
}
