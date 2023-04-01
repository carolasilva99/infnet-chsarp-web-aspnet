using AT.Models;
using AT.MVC.Models.Authors;
using AutoMapper;

namespace AT.MVC.Mapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>()
                .ForMember(m => m.FullName, d => d.MapFrom(mf => $"{mf.FirstName} {mf.LastName}" ));
            CreateMap<CreateAuthorViewModel, Author>();
            CreateMap<Author, CreateAuthorViewModel>();
            CreateMap<UpdateAuthorViewModel, Author>();
            CreateMap<Author, UpdateAuthorViewModel>();
            CreateMap<CreateBookAuthorViewModel, Author>();
            CreateMap<Author, BookAuthorViewModel>();
        }
    }
}
