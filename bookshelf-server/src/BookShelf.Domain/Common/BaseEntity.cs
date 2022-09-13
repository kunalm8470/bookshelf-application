using BookShelf.Domain.Interfaces;

namespace BookShelf.Domain.Common;

public abstract class BaseEntity<TKey> : IDatedEntity where TKey : struct
{
    public TKey Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
