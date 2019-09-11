using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class EmployeeLogin
    {
        public decimal EmployeeLoginId { get; set; }
        public decimal? EmpId { get; set; }
        public string Pass { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
