namespace Core.Constants;

public class Messages
{
    public const string BookNotFound = "Book not found";
    public const string AuthorNotFound = "Author not found";

    public const string EmptyBookList = "Book list is empty";
    public const string BookAddSuccessfull = "Book successfully added"; 
    public const string BookUpdateSuccessfull = "Book successfully updated"; 
    public const string BookAddError = "Error occured while adding the book to Database";
    public const string BookUpdateError = "Error occured while updating the book in the Database";

    public const string BookAlreadyExists = "A Book already exists with this name and Author";
    public const string IsbnAlreadyExist = "A Book already exists with this ISBN";

    public const string LendBookSuccessfull = "Book successfully lended";
    public const string ReturnBookSuccessfull = "Book successfully returned";
    public const string BookReturnDateError = "Book returned late!!! Dont forget to get money for extra days";

    public const string LendNotAllowed = "This user is not allowed to borrow the book. The user has an overdue book.";

}
