using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class PracaKoncowa
    {
        public DateTime TerminOddania { get; set; }
        public string Temat { get; set; } = null;
        public string Komentarze { get; set; } = null;
        public bool CzyTematZatwierdzony { get; set; } = false;
        public bool CzyOswiadczenieSamodzielnaPraca { get; set; } = false;
        public bool CzyOswiadczenieUdostepnieniePRacy { get; set; } = false;
        public bool CzyOswiadczenieTozsamoscPracy { get; set; } = false;
    }
}
