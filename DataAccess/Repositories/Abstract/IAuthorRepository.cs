using Models.Entities.Concrete;

namespace DataAccess.Repositories.Abstract;

public interface IAuthorRepository : IBaseRepository<Author>
{
    Task<Author?> GetAuthorByNameAsync(string name, CancellationToken ct);
}
