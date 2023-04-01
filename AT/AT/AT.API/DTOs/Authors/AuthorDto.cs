using AT.API.DTOs.Books;
using AT.Models;

namespace AT.API.DTOs.Authors
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<AuthorBookDto> Books { get; set; }
    }
}
