using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ThesisSubmission
    {
        public int SubmissionId { get; set; }
        public Lecturer ThesisPromoter { get; set; }
        public string thesisTopic { get; set; }
        public int TopicNumber { get; set; }
        public string ThesisObjectives { get; set; }
        public string ThesisScope { get; set; }
    }
}