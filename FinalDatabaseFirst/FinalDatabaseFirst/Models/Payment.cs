using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Orders>();
        }

        public decimal PaymentId { get; set; }
        public decimal? CreditCardId { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
