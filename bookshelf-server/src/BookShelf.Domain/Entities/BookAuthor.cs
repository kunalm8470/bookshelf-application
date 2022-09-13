using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class BookAuthor : BaseEntity<int>
{
    public string ISBN { get; set; }
    public Book Book { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
