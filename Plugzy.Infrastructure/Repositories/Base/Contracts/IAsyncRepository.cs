using System.Linq.Expressions;

namespace Plugzy.Infrastructure.Repositories.Base.Contracts;

public interface IAsyncRepository<TEntity> where TEntity : class, new()
{
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}
