using AT.MVC.Models.Authors;

namespace AT.MVC.Models.Books
{
    public class RemoveAuthorViewModel
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
