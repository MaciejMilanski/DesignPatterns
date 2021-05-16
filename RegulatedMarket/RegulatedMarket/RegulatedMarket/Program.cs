using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace RegulatedMarket
{
    class Program
    {
        private static List<Product> prodSet = new List<Product>(){
            new Product(Guid.NewGuid(), "Product0", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product1", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product2", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product3", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product4", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product5", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product6", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product7", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product8", Randomizer.GetRandomNumber(0, 100), Randomizer.GetRandomNumber(0,100))
            };        
        static void Main(string[] args)
        {
            double tax = 0.15;
            Bank bank = new Bank();

            List<Product> sellerSetList1 = new List<Product>();
            List<Product> sellerSetList2 = new List<Product>();
            List<Product> sellerSetList3 = new List<Product>();

            List<Product> consumerSetList1 = new List<Product>();
            List<Product> consumerSetList2 = new List<Product>();
            List<Product> consumerSetList3 = new List<Product>();

            SellerVisitor sellerVisitor = new SellerVisitor();
            ConsumerVisitor consumerVisitor = new ConsumerVisitor();

            
            for (int j = 0; j < 10; j++) 
            {
                sellerSetList1.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
                sellerSetList2.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
                sellerSetList3.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
            }
            for (int j = 0; j < 5; j++)
            {
                consumerSetList1.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
                consumerSetList2.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
                consumerSetList3.Add(prodSet[(int)Randomizer.GetRandomNumber(0, 8)].Clone());
            }

            //1.ustalamy poziom inflacji
            var inflation = Inflation.GetInstance(Randomizer.GetRandomNumber(0, 0.07));
            List<Seller> sellers = new List<Seller>() {
                    new Seller(Guid.NewGuid(), sellerSetList1, Randomizer.GetRandomNumber(0, 0.15), inflation, 0),
                    new Seller(Guid.NewGuid(), sellerSetList2, Randomizer.GetRandomNumber(0, 0.15), inflation, 0),
                    new Seller(Guid.NewGuid(), sellerSetList3, Randomizer.GetRandomNumber(0, 0.15), inflation, 0)
                };
            List<Consumer> consumers = new List<Consumer>()
                {
                    new Consumer(Guid.NewGuid(), consumerSetList1, inflation, Randomizer.GetRandomNumber(800, 1500)),
                    new Consumer(Guid.NewGuid(), consumerSetList1, inflation, Randomizer.GetRandomNumber(800, 1500)),
                    new Consumer(Guid.NewGuid(), consumerSetList1, inflation, Randomizer.GetRandomNumber(800, 1500))
                };

            bank.AttachSellers(sellers);
            bank.AttachConsumers(consumers);

            for (int i = 0; i <= 100; i++)
            {
                var partialIncoms = 0.0;   
                foreach (var seller in sellers)
                {
                    foreach (var consumer in consumers) 
                    {
                        foreach (var product in consumer.Preferences) 
                        {
                            var productsToSell = seller.ProductPrices.Where(x => x.Product.Name == product.Product.Name).ToList();//Wybieramy wszystkie produkty które kupujący chce kupić, a które sprzedawca ma
                            if (productsToSell.Count() > 0)
                            {
                                var productsToBuy = consumer.RateOffer(productsToSell);
                                if (productsToBuy.Count > 0) 
                                {
                                    var moneyToPay = 0.0;
                                    foreach (var productToBuy in productsToBuy)
                                    {
                                        moneyToPay += productToBuy.Price;
                                    }
                                    if (consumer.Money > moneyToPay)
                                    {
                                        consumer.Money -= moneyToPay;
                                        seller.Money += moneyToPay * (1 - tax); ;
                                        seller.OrderList = productsToBuy;
                                        seller.Accept(sellerVisitor);
                                        consumer.OrderList = productsToBuy;
                                        consumer.Accept(consumerVisitor);                                        
                                        bank.GetTaxes(moneyToPay * tax);
                                        partialIncoms += moneyToPay * tax;
                                        Console.WriteLine("Consumer Guid: "+ consumer.Guid + " bought products form seller Guid: " + seller.Guid);
                                    }
                                }                                
                            }                                                      
                        }                        
                    }

                }
                bank.RateIncoms(partialIncoms, inflation);
                bank.Notify();
                Console.WriteLine("New inflation: " + inflation.Value);
                int a = 1;
            }
        }      
    }
}
