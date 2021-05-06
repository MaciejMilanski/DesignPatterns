using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Objects;

namespace ObjectPool
{
    public class FactorialPool : GenericPool<Factorial>
    {
        private FactorialPool(Func<Factorial> objectGenerator, int maxCount, int minCount) : base(objectGenerator, maxCount, minCount) 
        { }

        private static FactorialPool _instance;
        private static readonly object _lock = new object();

        public static FactorialPool GetInstance(Func<Factorial> objectGenerator, int maxCount, int minCount)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                            {
                                _instance = new FactorialPool(objectGenerator, maxCount, minCount);
                            }
                }
            }
            return _instance;
        }
    }
}
