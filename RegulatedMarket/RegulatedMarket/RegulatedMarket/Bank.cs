using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Bank
    {
        public Dictionary<Product, double> ProductPrieces { get; set; }
        public Inflation inflation { get; set; } 
    }
}
