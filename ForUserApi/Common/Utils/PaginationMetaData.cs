namespace ForUserApi.Common.Utils;

public class PaginationMetaData
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public bool Previous { get; set; }
    public bool Next { get; set; }

    public PaginationMetaData(int count, int pageIndex, int pageSize)
    {
        CurrentPage = pageIndex;
        TotalPages = (int) Math.Ceiling((double) count / pageSize);
        PageSize = pageSize;
        Previous = 1 < pageIndex;
        Next = pageIndex < TotalPages;
    }
}
