namespace ComplexDataModel.Core.ApiQuery;

using Microsoft.EntityFrameworkCore;

public class QueryContainer<T>
{
    const int DEFAULT_PAGE_SIZE = 20;

    private IQueryable<T> queryable;
    private QueryOptions options;

    public IQueryable<T> Queryable => queryable;
    public QueryOptions Options => options;

    int GeneratePage(string page, int d) =>
        int.TryParse(page, out int _page)
            ? _page
            : d;

    bool GenerateSortDirection(string sort)
    {
        var split = sort.Split('_');

        if (split.Length > 1)
            return split[1].ToLower() == "desc";

        return false;
    }

    public QueryContainer(IQueryable<T> queryable, string page, string pageSize, string search, string sort)
    {
        options = new QueryOptions
        {
            Page = string.IsNullOrWhiteSpace(page)
                ? 1
                : GeneratePage(page, 1),
            PageSize = string.IsNullOrWhiteSpace(pageSize)
                ? DEFAULT_PAGE_SIZE
                : GeneratePage(pageSize, DEFAULT_PAGE_SIZE),
            Search = search,
            SortDescending = string.IsNullOrWhiteSpace(sort)
                ? false
                : GenerateSortDirection(sort),
            SortProperty = string.IsNullOrWhiteSpace(sort)
                ? "Id"
                : sort.Split('_')[0]
        };

        this.queryable = string.IsNullOrWhiteSpace(options.SortProperty)
            ? queryable
            : queryable.ApplySorting(options);
    }

    public async Task<QueryResult<T>> Query(Func<IQueryable<T>, string, IQueryable<T>> search)
    {
        if (!string.IsNullOrEmpty(Options.Search))
            queryable = search(Queryable, Options.Search);

        dynamic dynamicQueryable = Queryable;

        var totalCount = await EntityFrameworkQueryableExtensions.CountAsync(dynamicQueryable);

        if (totalCount <= ((Options.Page - 1) * Options.PageSize))
        {
            Options.Page = (int)System.Math.Ceiling((decimal)totalCount / Options.PageSize);
            Options.Page = Options.Page == 0
                ? 1
                : Options.Page;
        }

        return new QueryResult<T>
        {
            Page = Options.Page,
            PageSize = Options.PageSize,
            TotalCount = totalCount,
            Data = await Queryable
                .Skip((Options.Page - 1) * Options.PageSize)
                .Take(Options.PageSize)
                .ToListAsync()
        };
    }
}

public static class QueryExtensions
{
    public static QueryResult<C> Cast<T,C>(this QueryResult<T> result, List<C> data) => new QueryResult<C>
    {
        Data = data,
        Page = result.Page,
        PageSize = result.PageSize,
        TotalCount = result.TotalCount
    };
}