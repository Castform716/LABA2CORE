using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public string CardNumber { get; set; }
        public double? BalanceChange { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }

        public virtual Card CardNumberNavigation { get; set; }
    }
}
