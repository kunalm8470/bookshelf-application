using AutoMapper;
using BookShelf.Domain.Entities;
using BookShelf.Domain.Interfaces.Repositories;
using MediatR;

namespace BookShelf.Application.Authors.v1.Commands.CreateAuthor;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IMapper _mapper;

    public CreateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IMapper mapper
    )
    {
        _authorRepository = authorRepository;

        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        Author author = _mapper.Map<Author>(request);

        await _authorRepository.AddAsync(author, cancellationToken);

        return Unit.Value;
    }
}
