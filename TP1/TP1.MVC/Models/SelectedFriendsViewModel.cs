namespace TP1.MVC.Models
{
    public class SelectedFriendsViewModel
    {
        public static List<SelectedFriendViewModel> Friends { get; set; } = new List<SelectedFriendViewModel>();
        public SelectedFriendsViewModel()
        {
            Friends = new List<SelectedFriendViewModel>();
        }
        public IEnumerable<int> getSelectedIds()
        {
            return (from p in Friends where p.Selected select p.Id).ToList();
        }
    }
}
