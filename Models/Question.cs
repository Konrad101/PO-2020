using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Question
    {
<<<<<<< HEAD:Models/Recenzja.cs
        public Grade OcenaPracy { get; set; }
        public DateTime? DataRecenzji { get; set; } = null;
=======
        private int IdQuestion { get; set; }
        public string Content { get; set; }
        public int Points { get; set; }
        public string Answer { get; set; }
>>>>>>> TranslatingSecondHalfOfModel:Models/Question.cs
    }
}
