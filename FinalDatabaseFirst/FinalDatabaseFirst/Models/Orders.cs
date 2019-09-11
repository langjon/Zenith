using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Shipping = new HashSet<Shipping>();
        }

        public decimal OrderId { get; set; }
        public decimal? PaymentId { get; set; }
        public decimal? EmpId { get; set; }
        public decimal? ProdId { get; set; }
        public string StatusUpdate { get; set; }

        public virtual Employee Emp { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Product Prod { get; set; }
        public virtual ICollection<Shipping> Shipping { get; set; }
    }
}
