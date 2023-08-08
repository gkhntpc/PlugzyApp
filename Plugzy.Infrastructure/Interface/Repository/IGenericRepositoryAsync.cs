﻿using Plugzy.Domain.Abstract;
using Plugzy.Models.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Infrastructure.Interface.Repository
{
    public interface IGenericRepositoryAsync<T> where T : class, new()
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null!);
        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? filter = null, int index = 0, int size = 10,
                                        CancellationToken cancellationToken = default);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
