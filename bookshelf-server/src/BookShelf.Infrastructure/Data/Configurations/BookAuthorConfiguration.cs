using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder
        .HasKey(ba => ba.Id)
        .HasName("PK_BookAuthors_Id");

        builder
        .HasOne(ba => ba.Book)
        .WithMany(b => b.BookAuthors)
        .HasForeignKey(ba => ba.ISBN)
        .HasConstraintName("IX_BookAuthors_ISBN")
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasOne(ba => ba.Author)
        .WithMany(a => a.BookAuthors)
        .HasForeignKey(ba => ba.AuthorId)
        .HasConstraintName("IX_BookAuthors_AuthorId")
        .OnDelete(DeleteBehavior.Cascade);
    }
}
