namespace AT.Domain;

public class BookAuthor
{
    public int BookId { get; set; }
    public Book Book { get; set; }

    public string AuthorId { get; set; }
    public Author Author { get; set; }
}