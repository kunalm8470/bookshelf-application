using BookShelf.Domain.Entities;

namespace BookShelf.Domain.Interfaces.Repositories
{
    public interface IBookReviewRepository : IRepository<BookReview, int>
    {
        public Task AddReviewWithRatingAsync(string review, int rating, string userId, string isbn,  CancellationToken cancellationToken = default);
        public Task<IReadOnlyList<BookReview>> ListReviewsAsync(DateTime? searchAfter, int limit, CancellationToken cancellationToken = default);
    }
}
