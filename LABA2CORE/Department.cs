using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string FromBank { get; set; }
        public string Specialization { get; set; }
        public string WorkDays { get; set; }

        public virtual Bank FromBankNavigation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
