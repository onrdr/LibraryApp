namespace Core.Constants;

public class Messages
{
    public const string BookNotFound = "Book not found";
    public const string AuthorNotFound = "Author not found";
    public const string BorrowerNotFound = "Borrower not found";
    public const string UserNotFound = "User not found with this email";

    public const string EmptyBookList = "Book list is empty";
    public const string EmptyBorrowerList = "Borrower list is empty";

    public const string BookAddSuccessfull = "Book successfully added";
    public const string BookAddError = "Error occured while adding the book to Database";
    public const string BorrowerAddSuccessfull = "Borrower successfully created";
    public const string BorrowerAddError = "Error occured while adding the borrower to Database";

    public const string BookUpdateSuccessfull = "Book successfully updated";
    public const string BookUpdateError = "Error occured while updating the book in the Database";
    public const string BorrowerUpdateError = "Error occured while updating the borrower in the Database";

    public const string BorrowerDeleteSuccessfull = "Borrower successfully deleted";
    public const string BorrowerDeleteError = "Error occured while deleting the borrower from Database";

    public const string BookAlreadyExists = "A Book already exists with this name and Author";
    public const string BorrowerAlreadyExists = "A Borrower already exists with this Library Id. Please change Library Borrower Id";
    public const string IsbnAlreadyExists = "A Book already exists with this ISBN";

    public const string LendBookSuccessfull = "Book successfully lended";
    public const string ReturnBookSuccessfull = "Book successfully returned";
    public const string BookReturnDateError = "Book returned late!!! Dont forget to get money for extra days";

    public const string BookOverDueError = "This user is not allowed to borrow the book. The user has an overdue book.";
    public const string MaxBookCountError = "The user has reached max allowed number to borrow books";
    public const string BorrowerHasUnreturnedBooksError = "The user has unreturned books. You cannot delete";

    public const string LoginFailed = "Login failed !!! Please check your credentials";
    public const string LoginSuccessfull = "Login successfull";
    public const string LogoutSuccessfull = "Logout successfull";
    public const string InvalidCurrentPassword = "The current password is not correct";
    public const string PasswordChangeSuccess = "Password has successfully changed";
}
