﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalThesis
    {
        public int FinalThesisId { get; set; }
        public DateTime DeliveryDeadline { get; set; }
        public Participant Participant { get; set; }
    }
}
