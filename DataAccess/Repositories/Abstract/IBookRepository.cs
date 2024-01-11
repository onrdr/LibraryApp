using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetBookWithBorrowerAsync(Guid bookId, CancellationToken ct);
    Task<IEnumerable<Book>?> GetAllBooksWithAuthorAndBorrowerAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct);
}
