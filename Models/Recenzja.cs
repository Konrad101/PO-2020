using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Recenzja
    {
        public Ocena OcenaPracy { get; set; }
        public DateTime? DataRecenzji { get; set; } = null;
    }
}
