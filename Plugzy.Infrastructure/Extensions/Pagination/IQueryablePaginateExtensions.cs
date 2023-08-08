using Microsoft.EntityFrameworkCore;

using Plugzy.Models.Base;

namespace Plugzy.Infrastructure.Extensions.Pagination;

public static class IQueryablePaginateExtensions
{
    public static async Task<IPaginate<T>> ToPaginateAsync<T>(this IQueryable<T> source, int index, int size,
                                                              int from = 0,
                                                              CancellationToken cancellationToken = default)
    {
        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

        int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
        List<T> items = await source.Skip((index - from) * size).Take(size).ToListAsync(cancellationToken)
                                    .ConfigureAwait(false);
        Paginate<T> list = new()
        {
            CurrentPage = index,
            PageSize = size,
            From = from,
            TotalCount = count,
            Items = items,
            TotalPageCount = (int)Math.Ceiling(count / (double)size)
        };
        return list;
    }

    public static IPaginate<T> ToPaginate<T>(this IQueryable<T> source, int index, int size,
                                             int from = 0)
    {
        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must from <= Index");

        int count = source.Count();
        List<T> items = source.Skip((index - from) * size).Take(size).ToList();
        Paginate<T> list = new()
        {
            CurrentPage = index,
            PageSize = size,
            From = from,
            TotalCount = count,
            Items = items,
            TotalPageCount = (int)Math.Ceiling(count / (double)size)
        };
        return list;
    }
}
