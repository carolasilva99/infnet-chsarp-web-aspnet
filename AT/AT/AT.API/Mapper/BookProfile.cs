using AT.API.DTOs.Books;
using AT.Models;
using AutoMapper;

namespace AT.API.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();
            CreateMap<Book, AuthorBookDto>();
        }
    }
}
