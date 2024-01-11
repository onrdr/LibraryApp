using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Concrete;

namespace DataAccess.Repositories.Concrete;

public class AuthorRepository(ApplicationDbContext dbContext) : BaseRepository<Author>(dbContext), IAuthorRepository
{
    public async Task<Author?> GetAuthorByNameAsync(string name, CancellationToken ct)
    {
        var author = await _dataContext.Authors
            .FirstOrDefaultAsync(a => a.Name.ToLower().Trim() == name.ToLower().Trim(), ct);

        return author;
    }
}
