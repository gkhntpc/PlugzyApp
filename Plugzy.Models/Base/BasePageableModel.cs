namespace Plugzy.Models.Base;

public class BasePageableModel
{
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPageCount { get; set; }
}
