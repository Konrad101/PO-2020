namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Lecturer : User
    {
        public int LecturerId { get; set; }
        public User User { get; set; }
    }
}
