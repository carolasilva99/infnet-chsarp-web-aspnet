using System.ComponentModel.DataAnnotations;

namespace AT.MVC.Models.Account
{
    public class CreateViewModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; init; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init; }
        public string ReturnUrl { get; init; }
    }
}
