using AT.MVC.Models.Books;

namespace AT.MVC.Models.Authors
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<AuthorBookViewModel> Books { get; set; }
    }
}
