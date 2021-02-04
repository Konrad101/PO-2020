namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public int Points { get; set; }
        public string Answer { get; set; }
        public FinalExam FinalExams { get; set; }
    }
}
