using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CreditCard = new HashSet<CreditCard>();
        }

        public decimal CusId { get; set; }
        public string CusName { get; set; }
        public string CusPhone { get; set; }
        public string CusEmail { get; set; }
        public string CusAddress { get; set; }
        public string CusPostalCode { get; set; }

        public virtual ICollection<CreditCard> CreditCard { get; set; }
    }
}
