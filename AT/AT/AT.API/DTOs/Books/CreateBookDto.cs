using AT.API.DTOs.Authors;
using AT.Models;

namespace AT.API.DTOs.Books
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public ICollection<CreateBookAuthorDto> Authors { get; set; }
    }
}
