using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class Genre : BaseEntity<int>
{
    public string Name { get; set; }

    public ICollection<BookGenre> BookGenres { get; set; }
}
