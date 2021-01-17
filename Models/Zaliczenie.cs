using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Zaliczenie
    {
        public DateTime? TerminZaliczenia { get; set; } = null;
        public Grade OcenaZaliczenia { get; set; } = Grade.Brak;
        public DateTime? DataWystawieniaOceny { get; set; } = null;
        public string FormaZaliczenia { get; set; } = null;
    }
}
