using System.ComponentModel.DataAnnotations;

namespace TP1.MVC.Models
{
    public class FriendViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public bool Selected { get; set; }
    }
}
