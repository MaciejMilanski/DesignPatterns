using System;
using System.Collections.Generic;
using System.Threading;

namespace RegulatedMarket
{
    class Program
    {
        private static Random random = new Random();
        private static List<Product> prodSet1 = new List<Product>(){
            new Product(Guid.NewGuid(), "Product11", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product12", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product13", GetRandomNumber(0,100))
            };
        private static List<Product> prodSet2 = new List<Product>(){
            new Product(Guid.NewGuid(), "Product21", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product22", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product23", GetRandomNumber(0,100))
            };
        private static List<Product> prodSet3 = new List<Product>(){
            new Product(Guid.NewGuid(), "Product31", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product32", GetRandomNumber(0,100)),
            new Product(Guid.NewGuid(), "Product33", GetRandomNumber(0,100))
            };
        static void Main(string[] args)
        {
            List<List<Product>> setsList = new List<List<Product>>();
            setsList.Add(prodSet1);
            setsList.Add(prodSet2);
            setsList.Add(prodSet3);
            Shuffle<List<Product>>(setsList);


            for (int i = 0; i <= 100; i++)
            {
                //1.ustalamy poziom inflacji
                var inflation = Inflation.GetInstance(GetRandomNumber(0,0.07));
                var seller1 = new Seller(Guid.NewGuid(), setsList[1], GetRandomNumber(0, 0.15), inflation, 0);
                var seller2 = new Seller(Guid.NewGuid(), setsList[2], GetRandomNumber(0, 0.15), inflation, 0);
                var seller3 = new Seller(Guid.NewGuid(), setsList[3], GetRandomNumber(0, 0.15), inflation, 0);
                var seller4 = new Seller(Guid.NewGuid(), setsList[0], GetRandomNumber(0, 0.15), inflation, 0);


            }
        }
        static public double GetRandomNumber(double min, double max)
        {
            return random.NextDouble() * (min - max) + max;
        }
        public static void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
