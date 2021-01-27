using System;

namespace PO_implementacja_StudiaPodyplomowe.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string MailingAddress { get; set; }
        public string Degree { get; set; }
    }
}
