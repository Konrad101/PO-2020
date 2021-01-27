using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ThesisSubmission
    {
        public ThesisStatus Status { get; set; }
        public string ThesisScope { get; set; }
        public int TopicNumber { get; set; }
        public string ThesisObjectives { get; set; }
        public Lecturer ThesisPromoter { get; set; }
        public int SubmissionId { get; set; }
        public string thesisTopic { get; set; }
    }
}