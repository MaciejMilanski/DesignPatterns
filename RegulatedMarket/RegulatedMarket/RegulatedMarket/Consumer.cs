using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Consumer
    {
        public Guid Guid { get; set; }
        public Dictionary<Product, double> IntentionToBuy { get; set; }
        public Inflation inflation {get; set;}
        public double Money { get; set; }
    }
}
