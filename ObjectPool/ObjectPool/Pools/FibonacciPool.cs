using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Objects;

namespace ObjectPool
{
    public class FibonnaciPool : GenericPool<Fibonacci>
    {
        private FibonnaciPool(Func<Fibonacci> objectGenerator, int maxCount, int minCount) : base(objectGenerator, maxCount, minCount)//TODO poczytać o base
        { }

        private static FibonnaciPool _instance;
        private static readonly object _lock = new object();

        public static FibonnaciPool GetInstance(Func<Fibonacci> objectGenerator, int maxCount, int minCount)
        {
            if (_instance == null)
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FibonnaciPool(objectGenerator, maxCount, minCount);

                    }
                }
            }
            return _instance;
        }
    }
}
