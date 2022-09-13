using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Data.Repositories;

public class BookShelfRepository : Repository<BookShelfBook, int>, IBookShelfRepository
{
    private readonly BookshelfDbContext _dbContext;

    public BookShelfRepository(BookshelfDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<BookShelfBook>> ListBookShelfBooksAsync(DateTime? searchAfter, int limit, CancellationToken cancellationToken = default)
    {
        IQueryable<BookShelfBook> query = _dbContext.BookShelfBooks.AsQueryable();

        // Add search after to the query if provided
        if (searchAfter is not null)
        {
            query = query.Where(s => s.CreatedAt > searchAfter.Value);
        }

        return await query
                .Include(s => s.Book)
                .OrderBy(s => s.CreatedAt)
                .Take(limit)
                .ToListAsync(cancellationToken);
    }
}
