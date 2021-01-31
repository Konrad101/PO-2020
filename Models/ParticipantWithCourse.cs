using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ParticipantWithCourse
    {
        public Participant Participant { get; set; }
        public Course Course { get; set; }
        public ParticipantGradeList ParticipantGradeList { get; set; }
    }
}
