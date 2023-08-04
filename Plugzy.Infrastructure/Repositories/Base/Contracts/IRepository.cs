using System.Linq.Expressions;

namespace Plugzy.Infrastructure.Repositories.Base.Contracts;

public interface IRepository<TEntity> where TEntity : class, new()
{
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate);
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}
