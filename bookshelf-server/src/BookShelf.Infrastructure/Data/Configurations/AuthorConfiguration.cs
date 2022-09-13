using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder
        .HasKey(a => a.Id)
        .IsClustered()
        .HasName("PK_Authors_Id");

        builder
        .Property(a => a.FirstName)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(a => a.LastName)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(a => a.Bio)
        .HasMaxLength(10000);

        builder
        .Property(a => a.DateOfBirth)
        .IsRequired();
    }
}
