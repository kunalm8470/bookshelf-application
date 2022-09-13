using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Stubs;

public class AuthorStub
{
    public static IEnumerable<Author> GetAuthors()
    {
        yield return new Author
        {
            FirstName = "William",
            LastName = "Shakespeare",
            Bio = "William Shakespeare was an English playwright, poet and actor. He is widely regarded as the greatest writer in the English language and the world's greatest dramatist. He is often called England's national poet and the \"Bard of Avon\".",
            DateOfBirth = DateTime.Parse("1564-04-26T00:00:00Z"),
            DateOfDeath = DateTime.Parse("1616-04-23T00:00:00Z"),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new Author
        {
            FirstName = "Robert",
            LastName = "Kiyosaki",
            Bio = "Robert Toru Kiyosaki is an American businessman and author. Kiyosaki is the founder of Rich Global LLC and the Rich Dad Company, a private financial education company that provides personal finance and business education to people through books and videos.",
            DateOfBirth = DateTime.Parse("1947-04-08T00:00:00Z"),
            DateOfDeath = null,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
