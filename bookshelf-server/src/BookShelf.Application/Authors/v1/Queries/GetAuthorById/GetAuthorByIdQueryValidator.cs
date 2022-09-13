using FluentValidation;

namespace BookShelf.Application.Authors.v1.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(x => x.AuthorId)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Limit cannot be empty.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Limit cannot be negative.");
        }
    }
}
