using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Uczestnik
    {
        private int IdU { get; set; }
        public string Indeks { get; set; }
        public string DrugieImieU { get; set; }
        public string Pesel { get; set; }
        public string NumerTelefonu { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string ImieMatki { get; set; }
        public string ImieOjca { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public bool StatusAktywnegoUczestnika { get; set; } = true;
        public bool CzyZdanyEgzaminKoncowy { get; set; } = false;
    }
}