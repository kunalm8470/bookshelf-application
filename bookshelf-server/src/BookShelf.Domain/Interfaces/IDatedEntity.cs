namespace BookShelf.Domain.Interfaces;

public interface IDatedEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
