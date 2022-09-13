using BookShelf.Domain.Entities;
using BookShelf.Infrastructure.Data.Interceptors;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookShelf.Infrastructure.Data;

public class BookshelfDbContext : DbContext
{
    public BookshelfDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<BookReview> BookReviews { get; set; }
    public DbSet<BookShelfBook> BookShelfBooks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseExceptionProcessor();

        optionsBuilder.AddInterceptors(new TimestampInterceptor());

        base.OnConfiguring(optionsBuilder);
    }
}
