using AT.Models;
using AT.MVC.Models.Books;
using AutoMapper;

namespace AT.MVC.Mapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, CreateBookViewModel>();
            CreateMap<UpdateBookViewModel, Book>();
            CreateMap<Book, UpdateBookViewModel>();
            CreateMap<Book, AuthorBookViewModel>();
        }
    }
}
