﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class Attendance
    {
        public Participant Participant { get; set; }
        public ClassesUnit ClassesUnit { get; set; }
    }
}
