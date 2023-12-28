using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class LendBookViewModel
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string BorrowedBy { get; set; }

    [Required]
    public DateTimeOffset ReturnDate { get; set; }

    public string ImageUrl { get; set; }
}
