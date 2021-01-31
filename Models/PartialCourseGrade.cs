using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class PartialCourseGrade
    {
        public int PartialGradeId { get; set; }
        public DateTime GradeDate { get; set; }
        public Grade GradeValue { get; set; }
        public string Comment { get; set; }
        public ParticipantGradeList ParticipantGradeList { get; set; }
    }
}
