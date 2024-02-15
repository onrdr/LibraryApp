using Business.Services.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Repositories.Abstract;
using Models.Entities.Concrete;
using Models.ViewModels;
using System.Linq.Expressions;
using AutoMapper;

namespace Business.Services.Concrete;

public class BookService(
    IBookRepository _bookRepository,
    IAuthorService _authorService,
    IBorrowerService _borrowerService,
    IMapper _mapper) : IBookService
{
    #region Read Book / Books
    public async Task<IDataResult<ListBookViewModel>> GetBookByIdAsync(Guid categoryId, CancellationToken ct)
    {
        var book = await _bookRepository.GetByIdAsync(categoryId, ct);

        return book is not null
            ? new SuccessDataResult<ListBookViewModel>(data: _mapper.Map<ListBookViewModel>(book))
            : new ErrorDataResult<ListBookViewModel>(message: Messages.BookNotFound);
    }

    public async Task<IDataResult<IEnumerable<ListBookViewModel>>> GetAllBooksWithAuthorAndBorrowerAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct)
    {
        var bookList = await _bookRepository.GetAllBooksWithAuthorAndBorrowerAsync(predicate, ct);

        return bookList is not null && bookList.Any()
            ? new SuccessDataResult<IEnumerable<ListBookViewModel>>(data: _mapper.Map<IEnumerable<ListBookViewModel>>(bookList))
            : new ErrorDataResult<IEnumerable<ListBookViewModel>>(message: Messages.EmptyBookList);
    }
    #endregion

    #region Add Book
    public async Task<IResult> AddBookAsync(AddBookViewModel model, CancellationToken ct)
    {
        var existResult = await CheckIfBookAlreadyExistsAsync(model, ct);
        if (!existResult.Success)
        {
            return existResult;
        }

        int addResult = await CompleteAddProcessAsync(model, ct);
        return addResult > 0
            ? new SuccessResult(Messages.BookAddSuccessfull)
            : new ErrorResult(Messages.BookAddError);
    }
    #endregion

    #region Update Book
    public async Task<IResult> UpdateLendedBookAsync(LendBookViewModel model, CancellationToken ct)
    {
        var book = await _bookRepository.GetByIdAsync(model.Id, ct);
        if (book is null)
        {
            return new ErrorResult(Messages.BookNotFound);
        }

        var borrowerResult = await _borrowerService.GetBorrowerIfAllowedToBorrowBooksAsync(model.BorrowerLibraryId, ct);
        if (!borrowerResult.Success)
        {
            return borrowerResult;
        }

        CompleteLendBookUpdate(model, book, borrowerResult.Data);
        return await GetUpdateResultAsync(book, ct);
    }

    public async Task<IResult> UpdateReturnedBookAsync(Guid bookId, CancellationToken ct)
    {
        var book = await _bookRepository.GetBookWithBorrowerAsync(bookId, ct);
        if (book is null)
        {
            return new ErrorResult(Messages.BookNotFound);
        }

        CompleteReturnBookUpdate(book);
        return await GetUpdateResultAsync(book, ct);
    }
    #endregion

    #region Helper Methods
    private async Task<IResult> CheckIfBookAlreadyExistsAsync(AddBookViewModel model, CancellationToken ct)
    {
        var bookExistWithIsbn = await _bookRepository.CheckIfBookAlreadyExistsWithIsbnAsync(model.ISBN, ct);
        if (bookExistWithIsbn)
        {
            return new ErrorResult(Messages.IsbnAlreadyExists);
        }

        return await CheckIfBookExistsWithSameNameAndSameAuthor(model, ct);
    }

    private async Task<IResult> CheckIfBookExistsWithSameNameAndSameAuthor(AddBookViewModel model, CancellationToken ct)
    {
        var bookExists = await _bookRepository.CheckIfBookExistsWithSameNameAndSameAuthor(model.Name, model.AuthorName, ct);
        return bookExists
            ? new ErrorResult(Messages.BookAlreadyExists)
            : new SuccessResult();
    }

    private async Task<int> CompleteAddProcessAsync(AddBookViewModel model, CancellationToken ct)
    {
        var bookToAdd = _mapper.Map<Book>(model);

        await AddAuthorToBookAsync(model, bookToAdd, ct);

        var addResult = await _bookRepository.AddAsync(bookToAdd, ct);
        return addResult;
    }

    private async Task AddAuthorToBookAsync(AddBookViewModel model, Book bookToAdd, CancellationToken ct)
    {
        var authorResult = await _authorService.GetAuthorByNameAsync(model.AuthorName, ct);
        if (!authorResult.Success)
        {
            var author = new Author { Name = model.AuthorName.Trim() };
            bookToAdd.Author = author;
            return;
        }

        bookToAdd.Author = authorResult.Data;
    }

    private static void CompleteLendBookUpdate(LendBookViewModel model, Book bookToUpdate, Borrower borrower)
    {
        bookToUpdate.IsAvailable = false;
        bookToUpdate.ReturnDate = model.ReturnDate;
        bookToUpdate.BorrowerId = borrower.Id;
    }

    private static void CompleteReturnBookUpdate(Book bookToUpdate)
    {
        bookToUpdate.IsAvailable = true;
        bookToUpdate.ReturnDate = null;
        bookToUpdate.BorrowerId = null;
    }

    private async Task<IResult> GetUpdateResultAsync(Book book, CancellationToken ct)
    {
        var updateResult = await _bookRepository.UpdateAsync(book, ct);
        return updateResult > 0
            ? new SuccessResult(Messages.BookUpdateSuccessfull)
            : new ErrorResult(Messages.BookUpdateError);
    }
    #endregion
}
