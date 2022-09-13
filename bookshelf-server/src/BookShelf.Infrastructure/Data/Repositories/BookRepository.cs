using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;

namespace BookShelf.Infrastructure.Data.Repositories;

public class BookRepository : Repository<Book, int>, IBookRepository
{
    private readonly BookshelfDbContext _dbContext;

    public BookRepository(BookshelfDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateBookWithAuthorAndGenresAsync(Book book, IEnumerable<int> authors, IEnumerable<int> genres, CancellationToken cancellationToken = default)
    {
        _dbContext.Books.Add(book);

        foreach (int authorId in authors)
        {
            _dbContext.BookAuthors.Add(new BookAuthor
            {
                AuthorId = authorId,
                Book = book
            });
        }

        foreach (int genreId in genres)
        {
            _dbContext.BookGenres.Add(new BookGenre
            {
                GenreId = genreId,
                Book = book
            });
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
