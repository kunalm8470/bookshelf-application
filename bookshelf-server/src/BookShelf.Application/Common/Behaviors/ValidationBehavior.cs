using BookShelf.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace BookShelf.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }    

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            ValidationContext<TRequest> context = new(request);

            ValidationResult[] validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            Dictionary<string, string[]> failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

            if (failures.Any())
                throw new InvalidRequestException(failures);
        }

        return await next();
    }
}
