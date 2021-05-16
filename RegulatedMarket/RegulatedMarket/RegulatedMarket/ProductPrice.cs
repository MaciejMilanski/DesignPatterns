using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class ProductPrice
    {
        public ProductPrice(Product _product, double _price)
        {
            Product = _product;
            Price = _price;
        }
        public Product Product {get; set;}
        public double Price { get; set; }
    }
}
