using System.Linq.Expressions;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Contexts;
using Plugzy.Infrastructure.Repositories.Base.Contracts;

namespace Plugzy.Infrastructure.Repositories.Base;

public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity>
where TEntity : class, new()
where TContext : IdentityDbContext<User, Role, Guid>
{
    protected TContext _context;

    public EfRepositoryBase(TContext context)
    {
        _context = context;
    }

    public TEntity Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return _context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>().AsQueryable();
        if (predicate is not null) queryable = queryable.Where(predicate);

        return queryable.ToList();
    }

    public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate)
    {
        IQueryable<TEntity> queryable = _context.Set<TEntity>().AsQueryable();
        if (predicate is not null) queryable = queryable.Where(predicate);

        return await queryable.ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }
}
