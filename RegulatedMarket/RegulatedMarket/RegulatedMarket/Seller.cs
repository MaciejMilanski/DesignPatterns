using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Seller
    {
        public Seller(Guid _guid, List<Product> _products, double _profitMargin, Inflation _inflation, double _money) 
        {
            Guid = _guid;
            Products = _products;
            ProfitMargin = _profitMargin;
            Inflation = _inflation;
            Money = _money;
        }
        public Guid Guid { get; set; }
        public List<Product> Products {get; set;}        
        public double ProfitMargin { get; set; }
        public Inflation Inflation { get; set; }
        public double Money { get; set; }
    }
}
