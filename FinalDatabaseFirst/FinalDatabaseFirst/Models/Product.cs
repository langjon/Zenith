using System;
using System.Collections.Generic;

namespace FinalDatabaseFirst.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Orders>();
            Production = new HashSet<Production>();
        }

        public decimal ProdId { get; set; }
        public string ProdType { get; set; }
        public string ProdSize { get; set; }
        public string ProdMaterial { get; set; }
        public decimal? ProdQuantity { get; set; }
        public string ProductBriefDescription { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Production> Production { get; set; }
    }
}
