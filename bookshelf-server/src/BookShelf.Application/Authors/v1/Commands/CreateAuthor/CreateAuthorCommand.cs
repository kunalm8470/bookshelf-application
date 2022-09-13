using MediatR;

namespace BookShelf.Application.Authors.v1.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
    }
}
