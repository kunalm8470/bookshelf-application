using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Interfaces.Repositories;

public interface IBookShelfRepository : IRepository<BookShelfBook, int>
{
    public Task<IReadOnlyList<BookShelfBook>> ListBookShelfBooksAsync(DateTime? searchAfter, int limit, CancellationToken cancellationToken = default);
}
