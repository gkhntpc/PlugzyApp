using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Abstract;
using Plugzy.Domain.Common;
using Plugzy.Infrastructure.Context;
using Plugzy.Infrastructure.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Infrastructure.Repository
{
    public class GenericRepositoryAsync<T>: IGenericRepositoryAsync<T> where T : class, IEntity, new()
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

