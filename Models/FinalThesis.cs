using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class FinalThesis
    {
        public DateTime DeliveryDeadline { get; set; }
        public string Topic { get; set; } = null;
        public List<string> Comments { get; set; } = null;
        public bool IfTopicApproved { get; set; } = false;
        public bool IfDeclarationOfIndependentThesis { get; set; } = false;
        public bool IfDeclarationOfShareThesis { get; set; } = false;
        public bool IfDeclarationOfIdentityThesis { get; set; } = false;
    }
}
