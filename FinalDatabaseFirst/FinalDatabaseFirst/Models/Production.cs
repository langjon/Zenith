using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Production
    {
        public decimal ProductionId { get; set; }
        public decimal? EmpId { get; set; }
        public decimal? ProdId { get; set; }
        public string StatusUpdate { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual Product Prod { get; set; }
    }
}
