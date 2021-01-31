using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ClassesUnit
    {
        public int ClassUnitId { get; set; }
        public DateTime ClassBeginning { get; set; }
        public DateTime ClassEnding { get; set; }
        public string ClassroomNumber { get; set; }
        public ClassesForm ClassesForm { get; set; }
        public Course ClassCourse { get; set; }
        public Lecturer ClassLecturer { get; set; }
    }
}
