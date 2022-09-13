using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
{
    public void Configure(EntityTypeBuilder<BookReview> builder)
    {
        builder
        .HasKey(br => br.Id)
        .HasName("PK_BookReviews_Id");

        builder.Property(br => br.Rating)
        .IsRequired(true);

        builder.Property(br => br.Review)
        .IsRequired(true)
        .HasMaxLength(10000);

        builder
        .HasOne(br => br.Book)
        .WithMany(b => b.BookReviews)
        .HasForeignKey(br => br.ISBN)
        .HasConstraintName("FK_BookReviews_ISBN");

        builder
        .HasOne(br => br.Profile)
        .WithMany(u => u.BookReviews)
        .HasForeignKey(bc => bc.UserId)
        .HasConstraintName("FK_BookReviews_UserId");

        builder
        .HasIndex(br => br.CreatedAt)
        .HasDatabaseName("IX_BookReviews_CreatedAt");
    }
}
