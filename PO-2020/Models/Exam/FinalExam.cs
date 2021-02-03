using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalExam
    {
        public int ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string Classroom { get; set; }
        public StudyFieldManager StudyFieldManager { get; set; }
    }
}
