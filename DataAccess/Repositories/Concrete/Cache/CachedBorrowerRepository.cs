using DataAccess.Repositories.Abstract;
using Microsoft.Extensions.Caching.Memory;
using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete.Cache;

public class CachedBorrowerRepository(
    BorrowerRepository _decorated,
    IMemoryCache _cache) : IBorrowerRepository
{
    private static readonly List<string> CachedKeys = [];

    public async Task<Borrower?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var key = $"get-by-id-{id}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetByIdAsync(id, ct);
        });
    }

    public async Task<Borrower?> GetBorrowerByLibraryBorrowerIdAsync(string libraryBorrowerId, CancellationToken ct)
    {
        var key = $"get-by-libraryBorrowerId-{libraryBorrowerId}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetBorrowerByLibraryBorrowerIdAsync(libraryBorrowerId, ct);
        });
    }

    public async Task<IEnumerable<Borrower>?> GetAllAsync(Expression<Func<Borrower, bool>> predicate, CancellationToken ct)
    {
        var key = $"get-all-borrowers";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAllAsync(predicate, ct);
        });
    }

    public async Task<IEnumerable<Borrower>?> GetAllBorrowersWithBooksAsync(Expression<Func<Borrower, bool>> predicate, CancellationToken ct)
    {
        var key = $"get-all-borrowers-with-books";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAllBorrowersWithBooksAsync(predicate, ct);
        });
    }

    public async Task<bool> DoesBorrowerHaveOverDueBookAsync(string libraryBorrowerId, CancellationToken ct)
    {
        return await _decorated.DoesBorrowerHaveOverDueBookAsync(libraryBorrowerId, ct);
    }

    public async Task<int> GetBorrowerBookCountAsync(string libraryBorrowerId, CancellationToken ct)
    {
        return await _decorated.GetBorrowerBookCountAsync(libraryBorrowerId, ct);
    }

    public async Task<int> AddAsync(Borrower entity, CancellationToken ct)
    {
        int result = await _decorated.AddAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }

    public async Task<int> UpdateAsync(Borrower entity, CancellationToken ct)
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
