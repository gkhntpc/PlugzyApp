namespace Plugzy.Models.Base;

public interface IPaginate<T>
{
    int From { get; }
    int CurrentPage { get; }
    int PageSize { get; }
    int TotalCount { get; }
    int TotalPageCount { get; }
    IList<T> Items { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}
