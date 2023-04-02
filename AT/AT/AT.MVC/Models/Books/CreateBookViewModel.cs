using System.ComponentModel.DataAnnotations;
using AT.MVC.Models.Authors;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AT.MVC.Models.Books
{
    public class CreateBookViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int Year { get; set; }

        public ICollection<CreateBookAuthorViewModel> Authors { get; set; } = new List<CreateBookAuthorViewModel>();
    }
}
