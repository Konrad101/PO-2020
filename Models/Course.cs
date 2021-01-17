using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int ECTSPoints { get; set; }
        public int Semester { get; set; }
    }
}
