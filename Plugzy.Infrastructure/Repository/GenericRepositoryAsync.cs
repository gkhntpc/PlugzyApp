using Microsoft.EntityFrameworkCore;

using Plugzy.Domain.Abstract;
using Plugzy.Infrastructure.Context;
using Plugzy.Infrastructure.Extensions.Pagination;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Models.Base;

using System.Linq.Expressions;

namespace Plugzy.Infrastructure.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class, new()
    {
        private readonly PlugzyDbContext _dbContext;
        public GenericRepositoryAsync(PlugzyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            var addedEntity = _dbContext.Add(entity);
            addedEntity.State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return entity;

        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            return await (filter == null ?
                    _dbContext.Set<T>().ToListAsync() :
                    _dbContext.Set<T>().Where(filter).ToListAsync());
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, int index = 0, int size = 10,
                                                CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = _dbContext.Set<T>();
            
            if (filter is not null)
                queryable = queryable.Where(filter);

            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task RemoveAsync(T entity)
        {
            var deletedEntity = _dbContext.Remove(entity);
            deletedEntity.State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var updatedEntity = _dbContext.Update(entity);
            updatedEntity.State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}

