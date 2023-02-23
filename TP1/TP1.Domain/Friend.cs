using System.ComponentModel.DataAnnotations;

namespace TP1.Domain
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}