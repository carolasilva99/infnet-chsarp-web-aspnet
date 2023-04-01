using AT.Models;
using AT.MVC.Models.Authors;
using AutoMapper;

namespace AT.MVC.Mapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<CreateAuthorViewModel, Author>();
            CreateMap<Author, CreateAuthorViewModel>();
            CreateMap<UpdateAuthorViewModel, Author>();
            CreateMap<Author, UpdateAuthorViewModel>();
            CreateMap<CreateBookAuthorViewModel, Author>();
            CreateMap<Author, BookAuthorViewModel>();
        }
    }
}
