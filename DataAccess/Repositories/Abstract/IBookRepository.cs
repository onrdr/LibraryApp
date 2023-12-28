using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<IEnumerable<Book>?> GetAllBooksWithAuthorAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct);
}
