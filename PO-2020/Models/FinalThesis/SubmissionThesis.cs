namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class SubmissionThesis
    {
        public int SubmissionId { get; set; }
        public string ThesisTopic { get; set; }
        public int TopicNumber { get; set; }
        public string ThesisObjectives { get; set; }
        public string ThesisScope { get; set; }
        public ThesisStatus Status { get; set; }
        public FinalThesis FinalThesis { get; set; }
        public Edition Edition { get; set; }
    }
}