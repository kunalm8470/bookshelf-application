using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Interfaces.Repositories;

public interface IBookRepository : IRepository<Book, int>
{
    public Task CreateBookWithAuthorAndGenresAsync(Book book, IEnumerable<int> authors, IEnumerable<int> genres, CancellationToken cancellationToken = default);
}
