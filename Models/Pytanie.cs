using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Pytanie
    {
        private int IdPytania { get; set; }
        public string Tresc { get; set; }
        public int Punkty { get; set; }
        public string Odpowiedz { get; set; }
    }
}
