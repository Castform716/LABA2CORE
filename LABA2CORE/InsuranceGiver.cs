using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class InsuranceGiver
    {
        public string InsuranceUsreou { get; set; }
        public string BankCountry { get; set; }
        public double? InsuranceAmount { get; set; }
        public string InsuranceObject { get; set; }

        public bool IsBank { get; set; } //new
        public virtual Bank InsuranceObjectNavigation { get; set; }
    }
}
