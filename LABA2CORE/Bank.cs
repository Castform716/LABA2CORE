using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Bank
    {
        public Bank()
        {
            Accounts = new HashSet<Account>();
            DepartmentsNavigation = new HashSet<Department>();
            InsuranceGivers = new HashSet<InsuranceGiver>();
        }

        public string Usreou { get; set; }
        public string Name { get; set; }
        public string Departments { get; set; }
        public double? OverallBalance { get; set; }
        public double? GoldCapacity { get; set; }
        public string OriginCountry { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Department> DepartmentsNavigation { get; set; }
        public virtual ICollection<InsuranceGiver> InsuranceGivers { get; set; }
    }
}
