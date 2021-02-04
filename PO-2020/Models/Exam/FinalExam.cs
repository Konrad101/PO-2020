using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalExam
    {
        public int ExamId { get; set; }
        public DateTime? ExamDate { get; set; } = null;
        public string Classroom { get; set; } = null;
        public StudyFieldManager StudyFieldManager { get; set; }
    }
}
