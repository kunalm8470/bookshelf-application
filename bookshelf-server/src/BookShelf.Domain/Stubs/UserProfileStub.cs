using BookShelf.Domain.Entities;
using BookShelf.Domain.Enums;

namespace BookShelf.Domain.Stubs;

public static class UserProfileStub
{
    public static IEnumerable<UserProfile> GetUserProfiles()
    {
        yield return new UserProfile
        {
            Id = 1,
            IdentityUserId = "auth0|6314a7b39ecfbf1957aab505",
            FirstName = "bshelf1",
            LastName = "11",
            Gender = Gender.Male,
            Username = "bshelf1",
            Email = "bshelf1111@mailinator.com",
            ProfilePicUrl = "image.jpg",
            DateOfBirth = DateTime.Parse("2022-09-05T00:00:00Z"),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = null
        };
    }
}
