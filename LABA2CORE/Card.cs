using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Card
    {
        public Card()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string CardNumber { get; set; }
        public string Itn { get; set; }
        public string TypeOfCard { get; set; }
        public DateTime DateOfExpire { get; set; }
        public int? Cvv { get; set; }
        public double? Percentage { get; set; }

        public virtual Customer ItnNavigation { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
