namespace Models.ViewModels;

public class ListBookViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ISBN { get; set; }
    public string AuthorName { get; set; }
    public bool IsAvailable { get; set; }
    public string? BorrowedBy { get; set; }
    public string? LibraryBorrowerId { get; set; }
    public DateTimeOffset? ReturnDate { get; set; }
    public string? ImageUrl { get; set; }
}
