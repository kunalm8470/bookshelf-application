using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Stubs;

public static class BookStub
{
    public static IEnumerable<Book> GetBooks()
    {
        yield return new Book
        {
            Id = 1,
            ISBN = "9788175992924",
            Title = "Hamlet",
            Publisher = "William Shakespeare",
            PublishDate = DateTime.Parse("2015-05-01T00:00:00Z"),
            Language = "English",
            Pages = 200,
            Synopsis = "In the Kingdom of Denmark on a cold winter night, appears the ghost of the deceased King. What happens when Hamlet, the Prince of Denmark, encounters his father's ghost which reveals to him the secrets of his father's murder, laying upon him the duty of revenge?Unconvinced and indecisive, Hamlet the Prince of Demark, re-enacts the murder to find the truth. Will he be able to unmask and avenge the brutal and cold-blooded murder of his father? Will his inner struggle between taking a revenge and his propensity to delay thwart his desires to act. A typical Elizabethan Revenge Play, Hamlet is Shakespeare's longest play and one of the most quoted works in English language. it is described as the world's most filmed story after Cinderella.",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };

        yield return new Book
        {
            Id = 2,
            ISBN = "9781612680194",
            Title = "Rich Dad Poor Dad: What the Rich Teach Their Kids About Money That the Poor and Middle Class Do Not!",
            Publisher = "Plata Publishing; Second edition (April 11, 2017)",
            PublishDate = DateTime.Parse("2017-04-17T00:00:00Z"),
            Language = "English",
            Pages = 336,
            Synopsis = "It's been nearly 25 years since Robert Kiyosaki’s Rich Dad Poor Dad first made waves in the Personal Finance arena.\r\nIt has since become the #1 Personal Finance book of all time... translated into dozens of languages and sold around the world.\r\n\r\nRich Dad Poor Dad is Robert's story of growing up with two dads — his real father and the father of his best friend, his rich dad — and the ways in which both men shaped his thoughts about money and investing. The book explodes the myth that you need to earn a high income to be rich and explains the difference between working for money and having your money work for you.\r\n\r\n20 Years... 20/20 Hindsight\r\nIn the 20th Anniversary Edition of this classic, Robert offers an update on what we’ve seen over the past 20 years related to money, investing, and the global economy. Sidebars throughout the book will take readers “fast forward” — from 1997 to today — as Robert assesses how the principles taught by his rich dad have stood the test of time.\r\n\r\nIn many ways, the messages of Rich Dad Poor Dad, messages that were criticized and challenged two decades ago, are more meaningful, relevant and important today than they were 20 years ago.\r\n\r\nAs always, readers can expect that Robert will be candid, insightful... and continue to rock more than a few boats in his retrospective.\r\n\r\nWill there be a few surprises? Count on it.\r\n\r\nRich Dad Poor Dad...\r\n• Explodes the myth that you need to earn a high income to become rich\r\n• Challenges the belief that your house is an asset\r\n• Shows parents why they can't rely on the school system to teach their kids\r\nabout money\r\n• Defines once and for all an asset and a liability\r\n• Teaches you what to teach your kids about money for their future financial success.",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
