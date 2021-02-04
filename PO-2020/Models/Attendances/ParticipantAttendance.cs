using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class ParticipantAttendance
    {
        public DateTime AttendanceDate { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public int AttendanceValue { get; set; }
    }
}
