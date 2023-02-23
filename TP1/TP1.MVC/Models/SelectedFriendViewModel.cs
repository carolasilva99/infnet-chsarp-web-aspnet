using System.ComponentModel.DataAnnotations;

namespace TP1.MVC.Models
{
    public class SelectedFriendViewModel
    {
        public bool Selected { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public override bool Equals(object? obj)
        {
            var compareTo = obj as SelectedFriendViewModel;

            return this.Id == compareTo?.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
