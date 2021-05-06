using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Objects;

namespace ObjectPool.Interfaces
{
    public interface ICalcThreadBuilder
    {
       // void Reset();
        Factorial TakeFactorial(EFunction eFunction);
        Fibonacci TakeFibonacci(EFunction eFunction);
        GDC2 TakeGDC2(EFunction eFunction);
    }
}
