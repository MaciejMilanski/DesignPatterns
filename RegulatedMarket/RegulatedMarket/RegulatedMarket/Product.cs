using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Product
    {
        public Product(Guid _guid, string _name, double _prodPrice, double _price) 
        {
            Guid = _guid;
            Name = _name;
            ProdPrice = _prodPrice;
            Price = _price;
        }
        public Product Clone() 
        {
            return (Product)MemberwiseClone();
        }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public double ProdPrice { get; set; }
        public double Price { get; set; }

    }
}
