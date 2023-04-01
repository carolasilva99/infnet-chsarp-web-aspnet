using AT.API.DTOs.Authors;
using AT.Models;

namespace AT.API.DTOs.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }
        public ICollection<BookAuthorDto> Authors { get; set; }
    }
}
