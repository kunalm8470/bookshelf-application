using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;

namespace BookShelf.Infrastructure.Data.Repositories;

public class UserProfileRepository : Repository<UserProfile, int>, IUserProfileRepository
{
    public UserProfileRepository(BookshelfDbContext dbContext) : base(dbContext)
    {

    }
}
