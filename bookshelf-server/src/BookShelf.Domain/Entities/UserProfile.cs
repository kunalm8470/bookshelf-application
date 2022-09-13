using BookShelf.Domain.Common;
using BookShelf.Domain.Enums;

namespace BookShelf.Domain.Entities;

public class UserProfile : BaseEntity<int>
{
    public string IdentityUserId { get; set; }
    public string ProfilePicUrl { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<BookReview> BookReviews { get; set; }
    public ICollection<BookShelfBook> BookShelfBooks { get; set; }
}
