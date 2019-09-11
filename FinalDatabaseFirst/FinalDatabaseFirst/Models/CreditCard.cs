using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class CreditCard
    {
        public CreditCard()
        {
            Payment = new HashSet<Payment>();
        }

        public decimal CreditCardId { get; set; }
        public decimal? CusId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardProvider { get; set; }
        public string CreditCardHolderName { get; set; }
        public string CreditCardSecurityCode { get; set; }

        public virtual Customer Cus { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
