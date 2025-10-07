using DataAccess.Repositories.Abstract;
using Microsoft.Extensions.Caching.Memory;
using Models.Entities.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete.Cache;

public class CachedBookRepository(
    BookRepository _decorated,
    IMemoryCache _cache) : IBookRepository
{
    private static readonly List<string> CachedKeys = [];

    public async Task<Book?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var key = $"get-by-id-{id}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetByIdAsync(id, ct);
        });
    }

    public async Task<Book?> GetBookWithBorrowerAsync(Guid bookId, CancellationToken ct)
    {
        var key = $"get-with-borrower-{bookId}";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetBookWithBorrowerAsync(bookId, ct);
        });
    }

    public async Task<IEnumerable<Book>?> GetAllAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct)
    {
        var key = $"get-all-books";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAllAsync(predicate, ct);
        });
    }

    public async Task<IEnumerable<Book>?> GetAllBooksWithAuthorAndBorrowerAsync(Expression<Func<Book, bool>> predicate, CancellationToken ct)
    {
        var key = $"get-all-books-with-author-and-borrower";

        return await _cache.GetOrCreateAsync(key, async entry =>
        {
            CachedKeys.Add(key);
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await _decorated.GetAllBooksWithAuthorAndBorrowerAsync(predicate, ct);
        });
    }

    public async Task<bool> CheckIfBookAlreadyExistsWithIsbnAsync(string isbn, CancellationToken ct)
        => await _decorated.CheckIfBookAlreadyExistsWithIsbnAsync(isbn, ct);

    public async Task<bool> CheckIfBookExistsWithSameNameAndSameAuthor(string bookName, string authorName, CancellationToken ct)
        => await _decorated.CheckIfBookExistsWithSameNameAndSameAuthor(bookName, authorName, ct);

    public async Task<int> AddAsync(Book entity, CancellationToken ct)
    {
        int result = await _decorated.AddAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }

    public async Task<int> UpdateAsync(Book entity, CancellationToken ct)
    {
        int result = await _decorated.UpdateAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }

    public async Task<int> DeleteAsync(Book entity, CancellationToken ct)
    {
        int result = await _decorated.DeleteAsync(entity, ct);
        RemoveAllCachedKeys(result);
        return result;
    }


    #region Helper Methods
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
    #endregion
}
