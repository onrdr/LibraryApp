using Core.Utilities.Results;
using Models.Entities.Concrete;
using Models.ViewModels;

namespace Business.Services.Abstract;

public interface IBorrowerService
{
    Task<IDataResult<Borrower>> GetBorrowerIfAllowedToBorrowBooksAsync(string librarBorrowerId, CancellationToken ct);
    Task<IResult> AddBorrowerAsync(AddBorrowerViewModel model, CancellationToken ct);
}
