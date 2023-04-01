using AT.MVC.Models.Authors;

namespace AT.MVC.Models.Books
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public ICollection<BookAuthorViewModel> Authors { get; set; }
    }
}
