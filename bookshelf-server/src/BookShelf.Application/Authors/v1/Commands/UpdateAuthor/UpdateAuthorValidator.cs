using FluentValidation;

namespace BookShelf.Application.Authors.v1.Commands.UpdateAuthor;

public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
{
	public UpdateAuthorValidator()
	{
        RuleFor(x => x.FirstName)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("Author's first name cannot be null/empty.")
        .Must(x => x.Length > 1)
        .WithMessage("Author's first name needs at least one character.")
        .Must(x => x.Length < 1000)
        .WithMessage("Author's first name cannot be more than 1000 characters.");

        RuleFor(x => x.LastName)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("Author's last name cannot be null/empty.")
        .Must(x => x.Length > 1)
        .WithMessage("Author's last name needs at least one character.")
        .Must(x => x.Length < 1000)
        .WithMessage("Author's last name cannot be more than 1000 characters.");

        RuleFor(x => x.DateOfBirth)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("Author's date of birth cannot be empty.");
    }
}
