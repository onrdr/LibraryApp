using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete;

public class BorrowerRepository(ApplicationDbContext context) 
    : BaseRepository<Borrower>(context), IBorrowerRepository
{
    public async Task<Borrower?> GetBorrowerByLibraryBorrowerIdAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var borrower = await _dataContext.Borrowers
            .FirstOrDefaultAsync(b => b.LibraryBorrowerId == libraryBorrowerId, ct);

        return borrower;
    }

    public async Task<bool> DoesBorrowerHaveOverDueBookAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var hasOverdueBook = await _dataContext.Borrowers
            .Where(b => b.LibraryBorrowerId == libraryBorrowerId)
            .SelectMany(b => b.BorrowedBooks)
            .AnyAsync(book => book.ReturnDate < DateTime.UtcNow, ct);

        return hasOverdueBook;
    }

    public async Task<int> GetBorrowerBookCountAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var bookCount = await _dataContext.Borrowers
            .Where(b => b.LibraryBorrowerId == libraryBorrowerId)
            .SelectMany(b => b.BorrowedBooks).CountAsync(ct);

        return bookCount;
    }

    public async Task<IEnumerable<Borrower>?> GetAllBorrowersWithBooksAsync(Expression<Func<Borrower, bool>> predicate, CancellationToken ct)
    {
        var borrowers = await _dataContext.Borrowers
            .Include(b => b.BorrowedBooks)
            .ToListAsync(ct);

        return borrowers;
    }

    public async Task<IEnumerable<Borrower>?> GetAllBorrowersAsync(CancellationToken ct)
    {
        var borrowers = await _dataContext.Borrowers.ToListAsync(ct);

        return borrowers;
    }

    public async Task<Borrower?> GetBorrowerWithBooksAsync(Guid id, CancellationToken ct)
    {
        var borrower = await _dataContext.Borrowers
            .Include(b => b.BorrowedBooks)
            .FirstOrDefaultAsync(b => b.Id == id, ct);

        return borrower;
    }
}
