using BookShelf.Domain.Stubs;
using Microsoft.Extensions.Logging;

namespace BookShelf.Infrastructure.Data;

public class BookshelfDbContextInitializer
{
    private readonly BookshelfDbContext _bookshelfDbContext;

    private readonly ILogger<BookshelfDbContextInitializer> _logger;

    public BookshelfDbContextInitializer(
        BookshelfDbContext bookshelfDbContext,
        ILogger<BookshelfDbContextInitializer> logger
    )
    {
        _bookshelfDbContext = bookshelfDbContext;
        
        _logger = logger;
    }

    public async Task SeedAsync()
    {
        try
        {
            _logger.LogInformation("Seeding data started at {startTime}", DateTime.UtcNow);
            
            await TrySeedAsync();
            
            _logger.LogInformation("Seeding data ended at {endTime}", DateTime.UtcNow);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");

            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        _bookshelfDbContext.Database.EnsureDeleted();

        _bookshelfDbContext.Database.EnsureCreated();

        // Seed Genres
        _bookshelfDbContext.Genres.AddRange(GenreStub.GetGenres());

        // Seed Authors
        _bookshelfDbContext.Authors.AddRange(AuthorStub.GetAuthors());

        // Seed Books
        _bookshelfDbContext.Books.AddRange(BookStub.GetBooks());

        // Seed User Profiles
        _bookshelfDbContext.Profiles.AddRange(UserProfileStub.GetUserProfiles());

        // Seed Book genres
        _bookshelfDbContext.BookGenres.AddRange(BookGenreStub.GetBookGenres());

        // Seed Book authors
        _bookshelfDbContext.BookAuthors.AddRange(BookAuthorStub.GetBookAuthors());

        // Seed Book reviews
        _bookshelfDbContext.BookReviews.AddRange(BookReviewStub.GetBookReviews());

        // Seed Bookshelf books
        _bookshelfDbContext.BookShelfBooks.AddRange(BookShelfBookStub.GetBookShelfBooks());

        await _bookshelfDbContext.SaveChangesAsync();
    }
}
