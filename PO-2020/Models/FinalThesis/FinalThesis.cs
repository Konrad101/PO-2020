using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalThesis
    {
        public int FinalThesisId { get; set; }
        public DateTime? DeliveryDeadline { get; set; } = null;
        public Participant Participant { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
