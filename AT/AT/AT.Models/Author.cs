namespace AT.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }
    }
}