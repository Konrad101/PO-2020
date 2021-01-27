using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Participant : User
    {
        public int ParticipantId { get; set; }
        public string Index { get; set; }
        public string SecondNameU { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ActiveParticipantStatus { get; set; } = true;
        public bool IfPassedFinalExam { get; set; } = false;
    }
}