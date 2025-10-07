using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract;

public interface IBorrowerRepository : IBaseRepository<Borrower>
{
    Task<Borrower?> GetBorrowerByLibraryBorrowerIdAsync(string libraryBorrowerId, CancellationToken ct);
    Task<IEnumerable<Borrower>?> GetAllBorrowersAsync(CancellationToken ct);
    Task<Borrower?> GetBorrowerWithBooksAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<Borrower>?> GetAllBorrowersWithBooksAsync(Expression<Func<Borrower, bool>> predicate, CancellationToken ct);
    Task<bool> DoesBorrowerHaveOverDueBookAsync(string libraryBorrowerId, CancellationToken ct);
    Task<int> GetBorrowerBookCountAsync(string libraryBorrowerId, CancellationToken ct);
}
