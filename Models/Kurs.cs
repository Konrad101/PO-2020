using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Kurs
    {
        public string IdKursu { get; set; }
        public string Nazwa { get; set; }
        public int PunktyECTS { get; set; }
        public int Semestr { get; set; }
    }
}
