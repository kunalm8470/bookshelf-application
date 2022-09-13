using AutoMapper;
using BookShelf.Domain.Entities;
using BookShelf.Domain.Exceptions;
using BookShelf.Domain.Interfaces.Repositories;
using MediatR;

namespace BookShelf.Application.Authors.v1.Commands.UpdateAuthor;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IMapper _mapper;

    public UpdateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IMapper mapper
    )
    {
        _authorRepository = authorRepository;

        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        Author found = await _authorRepository.FindByPrimaryKeyAsync(request.Id, cancellationToken);

        if (found is null)
        {
            throw new ItemNotFoundException($"No author found with the Id - {request.Id}");
        }

        found.FirstName = request.FirstName;

        found.LastName = request.LastName;
        
        found.Bio = request.Bio;
        
        found.DateOfBirth = request.DateOfBirth;
        
        found.DateOfDeath = request.DateOfDeath;

        await _authorRepository.UpdateAsync(found, cancellationToken);

        return Unit.Value;
    }
}
