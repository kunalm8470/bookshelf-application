using BookShelf.Domain.Entities;
using BookShelf.Domain.Enums;

namespace BookShelf.Domain.Stubs;

public static class BookShelfBookStub
{
    public static IEnumerable<BookShelfBook> GetBookShelfBooks()
    {
        yield return new BookShelfBook
        {
            State = BookShelfState.ToRead,
            ISBN = "9788175992924",
            UserId = "auth0|6314a7b39ecfbf1957aab505",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new BookShelfBook
        {
            State = BookShelfState.Reading,
            ISBN = "9781612680194",
            UserId = "auth0|6314a7b39ecfbf1957aab505",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
