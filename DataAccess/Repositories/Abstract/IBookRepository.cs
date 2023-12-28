using Models.Entities.Concrete;
using Models.ViewModels;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<IEnumerable<Book>?> GetAllBooksWithAuthorAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct);
    Task<bool> CanUserBorrowBook(LendBookViewModel model, CancellationToken ct);
}
