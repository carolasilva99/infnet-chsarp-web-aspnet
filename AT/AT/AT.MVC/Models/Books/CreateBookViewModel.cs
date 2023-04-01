using AT.MVC.Models.Authors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AT.MVC.Models.Books
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }
        public ICollection<CreateBookAuthorViewModel> Authors { get; set; }
    }
}
