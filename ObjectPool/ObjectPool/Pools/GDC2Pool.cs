using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Objects;

namespace ObjectPool
{
    public class GDC2Pool : GenericPool<GDC2>
    {
        private GDC2Pool(Func<GDC2> objectGenerator, int maxCount, int minCount) : base(objectGenerator, maxCount, minCount)
        { }

        private static GDC2Pool _instance;
        private static readonly object _lock = new object();

        public static GDC2Pool GetInstance(Func<GDC2> objectGenerator, int maxCount, int minCount)
        {
            if (_instance == null)
            {

                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GDC2Pool(objectGenerator, maxCount, minCount);

                    }
                }
            }
            return _instance;
        }
    }
}
