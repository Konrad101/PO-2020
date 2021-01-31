using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ThesisSubmission
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