using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class JednostkaZajec
    {
        public DateTime PoczatekZajec { get; set; }
        public DateTime KoniecZajec { get; set; }
        public String NumerSali { get; set; }
        public FormaZajec FormaJednostkiZajec { get; set; }
    }
}
