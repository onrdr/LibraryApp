using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete;

public class BookRepository(ApplicationDbContext dbContext) : BaseRepository<Book>(dbContext), IBookRepository
{
    public async Task<Book?> GetBookWithBorrowerAsync(Guid bookId, CancellationToken ct)
    {
        var book = await _dataContext.Books
        .Include(b => b.Borrower)
        .FirstOrDefaultAsync(b => b.Id == bookId, ct);

        return book;
    }

    public async Task<IEnumerable<Book>?> GetAllBooksWithAuthorAndBorrowerAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct)
    {
        var books = await _dataContext.Books
            .Where(predicate)
            .Include(b => b.Author)
            .Include(b => b.Borrower)
            .ToListAsync(ct);

        return books;
    }

    public async Task<bool> CheckIfBookAlreadyExistsWithIsbnAsync(string isbn, CancellationToken ct)
        =>  await _dataContext.Books.AnyAsync(b => b.ISBN == isbn, ct);

    public async Task<bool> CheckIfBookExistsWithSameNameAndSameAuthor(string bookName, string authorName, CancellationToken ct)
    {
        return await _dataContext.Books.AnyAsync(b => 
                b.Name.ToLower().Trim() == bookName.ToLower().Trim()
                && b.Author.Name.ToLower().Trim() == authorName.ToLower().Trim(), ct);
    }
}
