using AT.MVC.Models.Authors;

namespace AT.MVC.Models.Books
{
    public class RemoveAuthorViewModel
    {
        public BookViewModel Book { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}
