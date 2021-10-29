using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
            Cards = new HashSet<Card>();
        }

        public string Itn { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int Mfo { get; set; }
        public string LegalEntityIndividual { get; set; }
        public int? TrustLimit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int? Postcode { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
