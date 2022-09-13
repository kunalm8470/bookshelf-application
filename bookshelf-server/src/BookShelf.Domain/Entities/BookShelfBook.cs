using BookShelf.Domain.Common;
using BookShelf.Domain.Enums;

namespace BookShelf.Domain.Entities;

public class BookShelfBook : BaseEntity<int>
{
    public BookShelfState State { get; set; }
    public string ISBN { get; set; }
    public Book Book { get; set; }
    public string UserId { get; set; }
    public UserProfile Profile { get; set; }
}
