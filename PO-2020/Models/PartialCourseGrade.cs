using System;
using System.ComponentModel.DataAnnotations;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class PartialCourseGrade
    {
        public int PartialGradeId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime GradeDate { get; set; }
        public Grade GradeValue { get; set; }
        public string Comment { get; set; }
        public ParticipantGradeList ParticipantGradeList { get; set; }
    }
}
