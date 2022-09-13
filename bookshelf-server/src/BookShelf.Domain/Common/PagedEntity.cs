namespace BookShelf.Domain.Common;

public record Paging(string Previous, string Next);

public record PagedEntity<T> where T : class
{
    public IEnumerable<T> Data { get; }

    public Paging Paging { get; }

    public PagedEntity(IEnumerable<T> data, string prev, string next)
    {
        Data = data;

        Paging = new(prev, next);
    }
}
