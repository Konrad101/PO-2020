using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Passing
    {
        public DateTime? PassingDate { get; set; } = null;
        public Ocena PassingGrade { get; set; } = Ocena.Brak;
        public DateTime? DateOfAssesment { get; set; } = null;
        public string FormOfPassing { get; set; } = null;
    }
}
