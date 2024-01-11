using Core.Utilities.Results;
using Models.Entities.Concrete;
using Models.ViewModels;
using System.Linq.Expressions;

namespace Business.Services.Abstract;

public interface IBookService
{
    Task<IDataResult<ListBookViewModel>> GetBookByIdAsync(Guid categoryId, CancellationToken ct);
    Task<IDataResult<IEnumerable<ListBookViewModel>>> GetAllBooksWithAuthorAndBorrowerAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct);
    Task<IResult> AddBookAsync(AddBookViewModel model, CancellationToken ct);
    Task<IResult> UpdateLendedBookAsync(LendBookViewModel model, CancellationToken ct);
    Task<IResult> UpdateReturnedBookAsync(Guid bookId, CancellationToken ct);
}
