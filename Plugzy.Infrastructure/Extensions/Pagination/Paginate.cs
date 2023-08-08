using Plugzy.Models.Base;

namespace Plugzy.Infrastructure.Extensions.Pagination;

public class Paginate<T> : IPaginate<T>
{
    internal Paginate(IEnumerable<T> source, int index, int size, int from)
    {
        var enumerable = source as T[] ?? source.ToArray();

        if (from > index)
            throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

        if (source is IQueryable<T> queryable)
        {
            CurrentPage = index;
            PageSize = size;
            From = from;
            TotalCount = queryable.Count();
            TotalPageCount = (int)Math.Ceiling(TotalCount / (double)PageSize);

            Items = queryable.Skip((CurrentPage - From) * PageSize).Take(PageSize).ToList();
        }
        else
        {
            CurrentPage = index;
            PageSize = size;
            From = from;

            TotalCount = enumerable.Count();
            TotalPageCount = (int)Math.Ceiling(TotalCount / (double)PageSize);

            Items = enumerable.Skip((CurrentPage - From) * PageSize).Take(PageSize).ToList();
        }
    }

    internal Paginate()
    {
        Items = new T[0];
    }

    public int From { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPageCount { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => CurrentPage - From > 0;
    public bool HasNext => CurrentPage - From + 1 < TotalPageCount;
}

internal class Paginate<TSource, TResult> : IPaginate<TResult>
{
    public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
                    int index, int size, int from)
    {
        var enumerable = source as TSource[] ?? source.ToArray();

        if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

        if (source is IQueryable<TSource> queryable)
        {
            CurrentPage = index;
            PageSize = size;
            From = from;
            TotalCount = queryable.Count();
            TotalPageCount = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = queryable.Skip((CurrentPage - From) * PageSize).Take(PageSize).ToArray();

            Items = new List<TResult>(converter(items));
        }
        else
        {
            CurrentPage = index;
            PageSize = size;
            From = from;
            TotalCount = enumerable.Count();
            TotalPageCount = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = enumerable.Skip((CurrentPage - From) * PageSize).Take(PageSize).ToArray();

            Items = new List<TResult>(converter(items));
        }
    }


    public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        CurrentPage = source.CurrentPage;
        PageSize = source.PageSize;
        From = source.From;
        TotalCount = source.TotalCount;
        TotalPageCount = source.TotalPageCount;

        Items = new List<TResult>(converter(source.Items));
    }

    public int CurrentPage { get; }

    public int PageSize { get; }

    public int TotalCount { get; }

    public int TotalPageCount { get; }

    public int From { get; }

    public IList<TResult> Items { get; }

    public bool HasPrevious => CurrentPage - From > 0;

    public bool HasNext => CurrentPage - From + 1 < TotalPageCount;
}

public static class Paginate
{
    public static IPaginate<T> Empty<T>()
    {
        return new Paginate<T>();
    }

    public static IPaginate<TResult> From<TResult, TSource>(IPaginate<TSource> source,
                                                            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
    {
        return new Paginate<TSource, TResult>(source, converter);
    }
}
