using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using Xunit;
using System.Runtime.Serialization.Formatters.Binary;

namespace RegulatedMarket.Tests
{
    public class VisitorPatternTests
    {
        [Fact]
        public void Visitors_Visit()
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

            SellerVisitor sellerVisitor = new SellerVisitor();
            ConsumerVisitor consumerVisitor = new ConsumerVisitor();

            List<Product> sellerOrderList = new List<Product>();
            List<Product> consumerOrderList = new List<Product>();
            sellerOrderList.Add(products[0]);
            consumerOrderList.Add(products[0]);

            sellers.Last().OrderList = sellerOrderList;
            consumers.Last().OrderList = consumerOrderList;

            sellers.Last().Accept(sellerVisitor);
            consumers.Last().Accept(consumerVisitor);
                       
            Assert.True(sellers.Last().Products.Count == 2);
            Assert.True(consumers.Last().BuyedProducts.Count == 1);


        }
    }
}
