using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Randomizer
    {
        private static Random random = new Random();
        public static double GetRandomNumber(double min, double max)
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
