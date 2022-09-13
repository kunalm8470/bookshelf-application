using BookShelf.Domain.Common;

namespace BookShelf.Domain.Entities;

public class Author : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
}
