using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class Book : BaseEntity<int>
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public string Language { get; set; }
    public int Pages { get; set; }
    public string Synopsis { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<BookReview> BookReviews { get; set; }
    public ICollection<BookShelfBook> BookShelfBooks { get; set; }
}
