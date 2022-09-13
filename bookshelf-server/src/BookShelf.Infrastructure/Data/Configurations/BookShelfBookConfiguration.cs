using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class BookShelfBookConfiguration : IEntityTypeConfiguration<BookShelfBook>
{
    public void Configure(EntityTypeBuilder<BookShelfBook> builder)
    {
        builder
        .HasKey(bsb => bsb.Id)
        .HasName("PK_BookShelfBooks_Id");

        builder
        .Property(bsb => bsb.State)
        .IsRequired();

        builder
        .HasOne(bsb => bsb.Profile)
        .WithMany(u => u.BookShelfBooks)
        .HasForeignKey(bsb => bsb.UserId)
        .HasConstraintName("FK_BookShelfBooks_UserId");

        builder
        .HasOne(si => si.Book)
        .WithMany(b => b.BookShelfBooks)
        .HasForeignKey(si => si.ISBN)
        .HasConstraintName("FK_BookShelfBooks_ISBN");

        builder
        .HasIndex(bsb => bsb.CreatedAt)
        .HasDatabaseName("IX_BookShelfBooks_CreatedAt");
    }
}
