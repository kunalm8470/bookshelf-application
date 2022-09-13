using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Data.Repositories;

public class AuthorRepository : Repository<Author, int>, IAuthorRepository
{
    private readonly BookshelfDbContext _dbContext;

    public AuthorRepository(BookshelfDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Author> GetAuthorBackgroundAsync(int authorId, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Authors
            .Include(a => a.BookAuthors)
            .ThenInclude(b => b.Book)
            .FirstOrDefaultAsync(x => x.Id == authorId, cancellationToken);
    }
}
