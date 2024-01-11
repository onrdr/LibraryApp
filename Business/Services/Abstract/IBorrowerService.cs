using Core.Utilities.Results;
using Models.Entities.Concrete;
using Models.ViewModels;
using System.Linq.Expressions;

namespace Business.Services.Abstract;

public interface IBorrowerService
{
    Task<IDataResult<Borrower>> GetBorrowerIfAllowedToBorrowBooksAsync(string librarBorrowerId, CancellationToken ct);
    Task<IDataResult<IEnumerable<Borrower>>> GetAllBorrowersWithBooksAsync(Expression<Func<Borrower, bool>> predicate, CancellationToken ct);
    Task<IResult> AddBorrowerAsync(AddBorrowerViewModel model, CancellationToken ct);
}
