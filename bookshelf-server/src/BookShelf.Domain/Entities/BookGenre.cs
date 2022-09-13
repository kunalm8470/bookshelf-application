using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class BookGenre : BaseEntity<int>
{
    public string ISBN { get; set; }
    public Book Book { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
}
