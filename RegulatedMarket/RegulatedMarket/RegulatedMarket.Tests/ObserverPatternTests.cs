using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Xunit;
using System.Runtime.Serialization.Formatters.Binary;

namespace RegulatedMarket.Tests
{
    public class ObserverPatternTests
    {
        [Fact]
        public void BankSubscribers_NotifyChagne()
        {
            List<Product> products = new List<Product>() 
            {
            new Product(Guid.NewGuid(), "Product0", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product1", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product2", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            };
            Bank bank = new Bank();
            var inflation = Inflation.GetInstance(0.05);

            List<Seller> sellers = new List<Seller>()
            {
                new Seller(Guid.NewGuid(), products, 0.05, inflation, 100)
            };
            List<Consumer> consumers = new List<Consumer>()
            {
                new Consumer(Guid.NewGuid(), products, inflation, 1000)
            };
            List<double> pricesList = new List<double>();
            foreach (var productPrice in sellers.Last().ProductPrices) 
            {
                pricesList.Add(productPrice.Price);
            }

            List<double> preferencesList = new List<double>();
            foreach (var consumerPref in consumers.Last().Preferences)
            {
                preferencesList.Add(consumerPref.Preference);
            }

            inflation.Value = 0.1;
            bank.AttachSellers(sellers);
            bank.AttachConsumers(consumers);
            bank.Notify();

            for (int i = 0; i < pricesList.Count; i++) 
            {
                Assert.True(pricesList[i] < sellers.Last().ProductPrices[i].Price);
                Assert.True(preferencesList[i] < consumers.Last().Preferences[i].Preference);
            }


        }
    }
}
