namespace BookShelf.Domain.Interfaces.CrossCutting;

public interface ICurrentUserService
{
    public string UserId { get; }
}
