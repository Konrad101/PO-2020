using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Review
    {
        public Grade ThesisGrade { get; set; }
        public DateTime? ReviewDate { get; set; } = null;
    }
}
