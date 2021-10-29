using System;
using System.Collections.Generic;

#nullable disable

namespace LABA2CORE
{
    public partial class Employee
    {
        public string Itn { get; set; }
        public int Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public double Sallary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? PostCode { get; set; }
        public string Job { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
    }
}
