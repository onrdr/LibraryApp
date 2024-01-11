using DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Models.Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repositories.Concrete;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly ApplicationDbContext _dataContext;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext context)
    {
        _dataContext = context;
        _dbSet = _dataContext.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _dbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);

    public async Task<IEnumerable<T>?> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
        => await _dbSet.AsNoTracking().Where(predicate).ToListAsync(ct);

    public async Task<int> AddAsync(T entity, CancellationToken ct)
    {
        await _dbSet.AddAsync(entity, ct);
        return await _dataContext.SaveChangesAsync(ct);
    }

    public async Task<int> UpdateAsync(T entity, CancellationToken ct)
    {
        _dataContext.Update(entity);
        return await _dataContext.SaveChangesAsync(ct);
    }
}
