using System.ComponentModel.DataAnnotations;

namespace Models.ViewModels;

public class AddBookViewModel
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "ISBN must be exactly 8 characters.")]
    public string ISBN { get; set; }

    [Required]
    [Display(Name = "Author Name")]
    [StringLength(50)]
    public string AuthorName { get; set; }

    [Display(Name = "Image")]
    public string? ImageUrl { get; set; }
}
