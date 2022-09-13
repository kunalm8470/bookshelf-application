using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Stubs;

public static class BookAuthorStub
{
    public static IEnumerable<BookAuthor> GetBookAuthors()
    {
        yield return new BookAuthor
        {
            ISBN = "9788175992924",
            AuthorId = 1,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new BookAuthor
        {
            ISBN = "9781612680194",
            AuthorId = 2,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
