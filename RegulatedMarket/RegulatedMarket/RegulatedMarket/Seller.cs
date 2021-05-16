using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Seller : IObserver
    {
        public Seller(Guid _guid, List<Product> _products, double _profitMargin, Inflation _inflation, double _money) 
        {
            Guid = _guid;
            Products = _products;
            ProfitMargin = _profitMargin;
            Inflation = _inflation;
            Money = _money;
            ProductPrices = SetThePrice(Products, ProfitMargin);
        }
        private List<ProductPrice> SetThePrice(List<Product> products, double profitMarign) 
        {
            List<ProductPrice> result = new List<ProductPrice>();
            foreach (var product in products) 
            {
                var newPrice = new ProductPrice(product, product.ProdPrice * (profitMarign + 1));
                result.Add(newPrice);
            }
            return result;
        }
        public void Accept(SellerVisitor visitor) 
        {
            visitor.Visit(this);
        }
        public void Update(Bank bank)  
        {
            foreach (var product in ProductPrices) 
            {
                product.Price = product.Price * (1 + Inflation.Value);
            }            
        }
        public Guid Guid { get; set; }
        public List<Product> Products {get; set;}
        public List<Product> OrderList { get; set; }
        public double ProfitMargin { get; set; }
        public Inflation Inflation { get; set; }
        public double Money { get; set; }
        public List<ProductPrice> ProductPrices { get; set; }
    }
}
