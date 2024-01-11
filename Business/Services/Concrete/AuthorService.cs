using Business.Services.Abstract;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Repositories.Abstract;
using Models.Entities.Concrete;

namespace Business.Services.Concrete;

public class AuthorService(IAuthorRepository _authorRepository) : IAuthorService
{
    public async Task<IDataResult<Author>> GetAuthorByNameAsync(string name, CancellationToken ct)
    {
        var author = await _authorRepository.GetAuthorByNameAsync(name, ct);

        return author is null
            ? new ErrorDataResult<Author>(message: Messages.AuthorNotFound)
            : new SuccessDataResult<Author>(data: author);
    }
}
