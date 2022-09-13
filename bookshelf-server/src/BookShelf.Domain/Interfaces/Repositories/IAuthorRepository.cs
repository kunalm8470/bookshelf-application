using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Interfaces.Repositories;

public interface IAuthorRepository : IRepository<Author, int>
{
    Task<Author> GetAuthorBackgroundAsync(int authorId, CancellationToken cancellationToken = default);
}
