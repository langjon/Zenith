using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeLogin = new HashSet<EmployeeLogin>();
            Orders = new HashSet<Orders>();
            Production = new HashSet<Production>();
        }

        public decimal EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string EmpPostalCode { get; set; }

        public virtual ICollection<EmployeeLogin> EmployeeLogin { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Production> Production { get; set; }
    }
}
