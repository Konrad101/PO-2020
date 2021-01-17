using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public enum Ocena
    {
        Grade20, Grade30, Grade35, Grade40, Grade45, Grade50, Grade55, Brak
    }

    public class OcenaKonwerter
    {
        public double GetOcena(Ocena ocena)
        {
            switch (ocena)
            {
                case Ocena.Grade20:
                    return 2.0;
                case Ocena.Grade30:
                    return 3.0;
                case Ocena.Grade35:
                    return 3.5;
                case Ocena.Grade40:
                    return 4.0;
                case Ocena.Grade45:
                    return 4.5;
                case Ocena.Grade50:
                    return 5.0;
                case Ocena.Grade55:
                    return 5.5;
                default:
                    return 0;
            }

        }
    }
}
