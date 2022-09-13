using BookShelf.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BookShelf.Infrastructure.Data.Interceptors;

public class TimestampInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateTimestampForEntity(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateTimestampForEntity(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateTimestampForEntity(DbContext context)
    {
        if (context is null)
        {
            return; 
        }

        DateTime now = DateTime.UtcNow;

        foreach (EntityEntry entry in context.ChangeTracker.Entries())
        {
            // TODO: Find a way later to make more generic
            if (entry.Entity is BaseEntity<int> entity)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedAt = now;
                        break;

                    case EntityState.Modified:
                        entity.UpdatedAt = now;
                        break;
                }
            }
        }
    }
}
