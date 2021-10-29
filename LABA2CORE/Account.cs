using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Account
    {
        public string AccountNumber { get; set; }
        public string Usreou { get; set; }
        public string Itn { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public double? CreditSum { get; set; }

        public virtual Customer ItnNavigation { get; set; }
        public virtual Bank UsreouNavigation { get; set; }
    }
}
