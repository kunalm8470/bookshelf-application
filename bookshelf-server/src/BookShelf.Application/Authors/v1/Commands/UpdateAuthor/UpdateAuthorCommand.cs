using MediatR;

namespace BookShelf.Application.Authors.v1.Commands.UpdateAuthor;

public class UpdateAuthorCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bio { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfDeath { get; set; }
}
