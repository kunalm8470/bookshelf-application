using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
        .HasKey(b => b.ISBN)
        .IsClustered()
        .HasName("PK_Books_ISBN");

        builder
        .Property(b => b.ISBN)
        .HasMaxLength(13)
        .IsRequired();

        builder
        .Property(b => b.Publisher)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(b => b.PublishDate)
        .IsRequired();

        builder
        .Property(b => b.Language)
        .HasMaxLength(2000)
        .IsRequired();


        builder
        .Property(b => b.Title)
        .HasMaxLength(2000)
        .IsRequired();

        builder
        .Property(b => b.Pages)
        .IsRequired();

        builder
        .Property(b => b.Synopsis)
        .HasMaxLength(20000);

        builder
        .HasIndex(b => b.CreatedAt)
        .HasDatabaseName("IX_Books_CreatedAt");
    }
}
