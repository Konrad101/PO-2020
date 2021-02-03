using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ParticipantAttendance
    {
        public DateTime AttendanceDate { get; set; }
        public String StartTime { get; set; }
        public String StopTime { get; set; }
        public int AttendanceValue { get; set; }

    }
}
