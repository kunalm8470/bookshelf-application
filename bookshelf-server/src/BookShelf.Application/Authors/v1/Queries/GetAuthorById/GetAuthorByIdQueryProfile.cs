using AutoMapper;
using BookShelf.Domain.Entities;
using BookShelf.Domain.Extensions;

namespace BookShelf.Application.Authors.v1.Queries.GetAuthorById;

public class GetAuthorByIdQueryProfile : Profile
{
	public GetAuthorByIdQueryProfile()
	{
        CreateMap<Author, AuthorPreviewDto>()
        .ForMember(a => a.DateOfBirth, opt => opt.MapFrom(a => a.DateOfBirth.FormatToReadableDateString()))
        .ForMember(s => s.DateOfBirth, opt => opt.MapFrom(a => a.DateOfDeath.FormatToReadableDateString()))
        .ForMember(a => a.NotableWorks, opt => opt.MapFrom(a => a.BookAuthors.Select(x => x.Book.Title)));
    }
}
