using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Product
    {
        public Product(Guid _guid, string _name, double _price) 
        {
            Guid = _guid;
            Name = _name;
            Price = _price;
        }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
