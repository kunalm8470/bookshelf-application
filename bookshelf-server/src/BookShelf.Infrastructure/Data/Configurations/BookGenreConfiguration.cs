using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder
        .HasKey(bc => bc.Id)
        .HasName("PK_BookGenres_Id");

        builder
        .HasOne(bg => bg.Book)
        .WithMany(b => b.BookGenres)
        .HasForeignKey(bg => bg.ISBN)
        .HasConstraintName("IX_BookGenres_ISBN");

        builder
        .HasOne(bg => bg.Genre)
        .WithMany(g => g.BookGenres)
        .HasForeignKey(bg => bg.GenreId)
        .HasConstraintName("IX_BookGenres_GenreId");
    }
}
