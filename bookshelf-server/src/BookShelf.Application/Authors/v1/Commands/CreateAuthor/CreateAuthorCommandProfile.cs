using AutoMapper;
using BookShelf.Domain.Entities;

namespace BookShelf.Application.Authors.v1.Commands.CreateAuthor
{
    public class CreateAuthorCommandProfile : Profile
    {
        public CreateAuthorCommandProfile()
        {
            CreateMap<CreateAuthorCommand, Author>()
            .ForMember(x => x.FirstName, opt => opt.MapFrom(y => y.FirstName.Trim()))
            .ForMember(x => x.LastName, opt => opt.MapFrom(y => y.LastName.Trim()))
            .ForMember(x => x.Bio, opt => opt.MapFrom(y => y.Bio.Trim()))
            .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(y => y.DateOfBirth))
            .ForMember(x => x.DateOfDeath, opt => opt.MapFrom(y => y.DateOfDeath));
        }
    }
}
