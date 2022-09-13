using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Stubs;

public static class BookGenreStub
{
    public static IEnumerable<BookGenre> GetBookGenres()
    {
        yield return new BookGenre
        {
            ISBN = "9788175992924",
            GenreId = 8,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new BookGenre
        {
            ISBN = "9781612680194",
            GenreId = 24,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new BookGenre
        {
            ISBN = "9781612680194",
            GenreId = 35,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
