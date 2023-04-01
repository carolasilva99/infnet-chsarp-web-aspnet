using AT.API.DTOs.Authors;
using AT.Models;
using AutoMapper;

namespace AT.API.Mapper
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<CreateAuthorDto, Author>();
            CreateMap<UpdateAuthorDto, Author>();
            CreateMap<CreateBookAuthorDto, Author>();
            CreateMap<Author, BookAuthorDto>();
        }
    }
}
