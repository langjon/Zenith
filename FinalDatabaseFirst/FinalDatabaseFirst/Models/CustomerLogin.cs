using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalDatabaseFirst.Models
{
    public class CustomerLogin
    {
        public decimal? CusId { get; set; }
        public decimal UserName { get; set; }
       
        public string UserPass { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
