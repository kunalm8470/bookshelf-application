using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class BookReview : BaseEntity<int>
{
    public int Rating { get; set; }
    public string Review { get; set; }
    public string ISBN { get; set; }
    public Book Book { get; set; }
    public string UserId { get; set; }
    public UserProfile Profile { get; set; }
}
