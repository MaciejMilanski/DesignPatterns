using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Seller
    {
        public Guid Guid { get; set; }
        public List<Product> Products {get; set;}        
        public double ProfitMargin { get; set; }
    }
}
