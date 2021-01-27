using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class PartialGrade
    {
        public DateTime GradeDate { get; set; }
        public Grade GradeValue { get; set; }
        public string Comment { get; set; }
    }
}
