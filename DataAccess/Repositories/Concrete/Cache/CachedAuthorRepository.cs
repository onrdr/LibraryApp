using DataAccess.Repositories.Abstract;
using Microsoft.Extensions.Caching.Memory;
using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete.Cache;

public class CachedAuthorRepository(
    AuthorRepository _decorated,
    IMemoryCache _cache) : IAuthorRepository
{
    private static readonly List<string> CachedKeys = [];

    public async Task<Author?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var key = $"get-by-id-{id}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetByIdAsync(id, ct);
        });
    }

    public async Task<Author?> GetAuthorByNameAsync(string name, CancellationToken ct)
    {
        var key = $"get-author-by-name-{name.ToLower().Trim()}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAuthorByNameAsync(name, ct);
        });
    }

    public async Task<IEnumerable<Author>?> GetAllAsync(Expression<Func<Author, bool>> predicate, CancellationToken ct)
    {
        var key = $"get-all-authors";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAllAsync(predicate, ct);
        });
    }

    public async Task<int> AddAsync(Author entity, CancellationToken ct)
    {
        int result = await _decorated.AddAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }

    public async Task<int> UpdateAsync(Author entity, CancellationToken ct)
    {
        int result = await _decorated.UpdateAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }

    private void RemoveAllCachedKeys(int result)
    {
        if (result > 0)
        {
            foreach (var key in CachedKeys)
            {
                _cache.Remove(key);
            }

            CachedKeys.Clear();
        }
    }
}
