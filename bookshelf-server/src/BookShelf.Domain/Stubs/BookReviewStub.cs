using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Stubs
{
    public static class BookReviewStub
    {
        public static IEnumerable<BookReview> GetBookReviews()
        {
            yield return new BookReview
            {
                Rating = 8,
                Review = "You all are must be familiar with William Shakepeare and his work. And this particular play is considered one of the greatest play in english literature.\r\n\r\nAs per the book, the quality of book is really great, words are very clear and it is also in original language of Shakespeare. That's why first time readers may find it difficult to understand and need a dictionary. On the other hand daily reader who has read shakespeare's other play will not have any difficulty.",
                ISBN = "9788175992924",
                UserId = "auth0|6314a7b39ecfbf1957aab505"
            };

            yield return new BookReview
            {
                Rating = 9,
                Review = "This book is perhaps the best wealth building book available, teaching investing, accounting and money mindset in a manner that turns conventional thinking and formal education upside down. The book presented an alternate definition of “asset” and alternate perspective on accounting in a simplistic way that eclipsed the knowledge acquired with a business degree from a top university. Everyone who has a desire to build wealth and net worth should read this book.",
                ISBN = "9781612680194",
                UserId = "auth0|6314a7b39ecfbf1957aab505"
            };
        }
    }
}
