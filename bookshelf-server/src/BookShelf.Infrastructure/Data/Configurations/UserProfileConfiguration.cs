using BookShelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShelf.Infrastructure.Data.Configurations;

public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder
        .HasKey(u => u.IdentityUserId)
        .IsClustered()
        .HasName("PK_Profiles_IdentityUserId");

        builder
        .Property(u => u.FirstName)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(u => u.LastName)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(u => u.Gender)
        .IsRequired();

        builder
        .Property(u => u.Username)
        .HasMaxLength(1000)
        .IsRequired();

        builder
        .Property(u => u.Email)
        .HasMaxLength(320)
        .IsRequired();

        builder
        .Property(u => u.DateOfBirth)
        .IsRequired();

        builder
        .HasIndex(u => u.Email)
        .IsUnique()
        .HasDatabaseName("IX_Profiles_Email");

        builder
        .HasIndex(u => u.Username)
        .IsUnique()
        .HasDatabaseName("IX_Profiles_Username");
    }
}
