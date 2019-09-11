using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Shipping
    {
        public decimal ShippingId { get; set; }
        public decimal? OrderId { get; set; }
        public string TrackingCode { get; set; }

        public virtual Orders Order { get; set; }
    }
}
