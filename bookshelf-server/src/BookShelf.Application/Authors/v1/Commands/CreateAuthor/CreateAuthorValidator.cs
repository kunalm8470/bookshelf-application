using FluentValidation;
using FluentValidation.Results;

namespace BookShelf.Application.Authors.v1.Commands.CreateAuthor
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.FirstName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Author's first name cannot be null/empty.")
            .Must(x => x.Length > 1)
            .WithMessage("Author's first name more than one character.")
            .Must(x => x.Length < 1000)
            .WithMessage("Author's first name cannot be more than 1000 characters.");

            RuleFor(x => x.LastName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Author's last name cannot be null/empty.")
            .Must(x => x.Length > 1)
            .WithMessage("Author's last name needs more than one character.")
            .Must(x => x.Length < 1000)
            .WithMessage("Author's last name cannot be more than 1000 characters.");

            RuleFor(x => x.DateOfBirth)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Author's date of birth cannot be empty.");
        }
    }
}
