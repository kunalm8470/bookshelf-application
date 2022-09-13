using MediatR;

namespace BookShelf.Application.Authors.v1.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorPreviewDto>
    {
        public int AuthorId { get; set; }
    }
}
