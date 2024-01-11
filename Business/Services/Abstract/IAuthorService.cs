using Core.Utilities.Results;
using Models.Entities.Concrete;

namespace Business.Services.Abstract;

public interface IAuthorService
{
    Task<IDataResult<Author>> GetAuthorByNameAsync(string name, CancellationToken ct);
}
