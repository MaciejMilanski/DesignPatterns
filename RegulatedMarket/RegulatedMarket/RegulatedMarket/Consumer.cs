using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RegulatedMarket
{
    public class Consumer : IObserver
    {
        public Consumer(Guid _guid, List<Product> products, Inflation _inflation, double _money) 
        {
            Guid = _guid;            
            Inflation = _inflation;
            Money = _money;
            Preferences = RandomizePreferences(products);
            BuyedProducts = new List<Product>();
        }
        private List<ConsumerPreferences> RandomizePreferences(List<Product> products) 
        {
            List<ConsumerPreferences> result = new List<ConsumerPreferences>();
            foreach (var product in products) 
            {
                ConsumerPreferences consumerPreferences = new ConsumerPreferences();
                consumerPreferences.Product = product;
                consumerPreferences.Preference = Randomizer.GetRandomNumber(0, 1);
                result.Add(consumerPreferences);
            }
            return result;
        }
        public void Buy(List<Product> products) 
        {
            BuyedProducts.AddRange(products);
        }
        public List<Product> RateOffer(List<ProductPrice> productsPrice) 
        {
            List<Product> productsToBuy = new List<Product>();
            foreach (var productPrice in productsPrice)
            {
                var offerRatio = productPrice.Price / 100;
                var preferenceRatio = Preferences.Where(x => x.Product.Guid == productPrice.Product.Guid).Last().Preference;
                if (offerRatio > preferenceRatio)//jeżeli offer ratio wyżej niż offer ratio dla elementru
                    productsToBuy.Add(productPrice.Product);
            }
            return productsToBuy;
        }
        public void Update(Bank bank)
        {
            foreach (var product in Preferences)
            {
                product.Preference = product.Preference + Inflation.Value/2;
            }
        }
        public void Accept(ConsumerVisitor visitor) 
        {
            visitor.Visit(this);
        }
        public Guid Guid { get; set; }
        public Dictionary<Product, double> IntentionToBuy { get; set; }
        public Inflation Inflation {get; set;}
        public double Money { get; set; }
        public List<ConsumerPreferences> Preferences { get; set; }
        public List<Product> BuyedProducts { get; set; }
        public List<Product> OrderList { get; set; }
    }
}
