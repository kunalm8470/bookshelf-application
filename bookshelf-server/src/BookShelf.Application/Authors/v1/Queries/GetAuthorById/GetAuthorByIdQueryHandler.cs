using AutoMapper;
using BookShelf.Domain.Entities;
using BookShelf.Domain.Exceptions;
using BookShelf.Domain.Interfaces.Repositories;
using MediatR;

namespace BookShelf.Application.Authors.v1.Queries.GetAuthorById;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorPreviewDto>
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IMapper _mapper;

    public GetAuthorByIdQueryHandler(
        IAuthorRepository authorRepository,
        IMapper mapper
    )
    {
        _authorRepository = authorRepository;

        _mapper = mapper;
    }

    public async Task<AuthorPreviewDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        Author foundAuthor = await _authorRepository.GetAuthorBackgroundAsync(request.AuthorId, cancellationToken);

        if (foundAuthor is null) 
        {
            throw new ItemNotFoundException($"No author found with the Id - {request.AuthorId}");
        }

        return _mapper.Map<AuthorPreviewDto>(foundAuthor);
    }
}
