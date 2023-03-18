using System.ComponentModel.DataAnnotations;

namespace TP3.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
