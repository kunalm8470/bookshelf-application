using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Infrastructure.Data.Repositories
{
    public class BookReviewRepository : Repository<BookReview, int>, IBookReviewRepository
    {
        private readonly BookshelfDbContext _dbContext;

        public BookReviewRepository(BookshelfDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddReviewWithRatingAsync(string review, int rating, string userId, string isbn, CancellationToken cancellationToken = default)
        {
            BookReview bookReview = new()
            {
                Review = review,
                Rating = rating,
                ISBN = isbn,
                UserId = userId,
            };

            _dbContext.BookReviews.Add(bookReview);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<BookReview>> ListReviewsAsync(DateTime? searchAfter, int limit, CancellationToken cancellationToken = default)
        {
            IQueryable<BookReview> query = _dbContext.BookReviews.AsQueryable();

            // Add search after to the query if provided
            if (searchAfter is not null)
            {
                query = query.Where(s => s.CreatedAt > searchAfter.Value);
            }

            return await query
                    .Include(u => u.Profile)
                    .OrderBy(s => s.CreatedAt)
                    .Take(limit)
                    .ToListAsync(cancellationToken);
        }
    }
}
