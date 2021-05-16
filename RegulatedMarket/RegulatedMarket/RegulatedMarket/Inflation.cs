using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class Inflation
    {
        private Inflation(double value)
        {
            Value = value;
        }

        private static Inflation _instance;
        private static readonly object _lock = new object();

        public static Inflation GetInstance(double value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Inflation(value);
                    }
                }
            }
            return _instance;
        }
        public double Value { get; set; }
    }
}
