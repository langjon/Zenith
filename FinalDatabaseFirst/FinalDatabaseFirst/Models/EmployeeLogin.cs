using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalDatabaseFirst.Models
{
    public partial class EmployeeLogin
    {
        [Required]
        public string EmployeeLoginId { get; set; }

        public decimal? EmpId { get; set; }

        [Required, DataType(DataType.Password)]
        public string Pass { get; set; }

        public virtual Employee Emp { get; set; }
    }
}
