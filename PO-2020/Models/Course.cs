namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int ECTSPoints { get; set; }
        public int Semester { get; set; }
        public Edition Edition { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
