namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class StudyFieldManager : User
    {
        public int ManagerId { get; set; }
        public string PrimaryEmploymentPlace { get; set; }
        public User User { get; set; }
    }
}
