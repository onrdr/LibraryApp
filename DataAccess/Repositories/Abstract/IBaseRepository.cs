using Models.Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Abstract;

public interface IBaseRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
    Task<int> AddAsync(T entity, CancellationToken ct);
    Task<int> UpdateAsync(T entity, CancellationToken ct);
}
