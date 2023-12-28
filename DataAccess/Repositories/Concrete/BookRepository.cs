using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;
using Models.ViewModels;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete;

public class BookRepository(ApplicationDbContext dbContext) : BaseRepository<Book>(dbContext), IBookRepository
{
    public async Task<IEnumerable<Book>?> GetAllBooksWithAuthorAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct)
    {
        var books = await _dataContext.Books
            .Where(predicate)
            .Include(c => c.Author)
            .ToListAsync(ct);

        return books;
    }

    public async Task<bool> CanUserBorrowBook(LendBookViewModel model, CancellationToken ct)
    {
        var hasDueDatePastBook = await _dataContext.Books
            .AnyAsync(b =>
                b.BorrowedBy != null &&
                b.BorrowedBy.ToLower().Trim() == model.BorrowedBy.ToLower().Trim() &&
                b.ReturnDate < DateTime.Now, ct);

        return !hasDueDatePastBook;
    }
}
