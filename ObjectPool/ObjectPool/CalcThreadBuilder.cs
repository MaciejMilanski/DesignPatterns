using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Interfaces;
using ObjectPool.Objects;

namespace ObjectPool
{
    public class CalcThreadBuilder : ICalcThreadBuilder
    {
        public FactorialPool factorialPool;
        public FibonnaciPool fibonnaciPool;
        public GDC2Pool gdc2Pool;
         //private CalcThread thread = new CalcThread();
        public CalcThreadBuilder(int maxCount, int minCount)
        {
            PrototypesManager prototypesManager = new PrototypesManager();
            factorialPool = FactorialPool.GetInstance(prototypesManager.CreateFactorial, minCount, maxCount);
            fibonnaciPool = FibonnaciPool.GetInstance(prototypesManager.CreateFibonacci, minCount, maxCount);
            gdc2Pool = GDC2Pool.GetInstance(prototypesManager.CreateGDC2, minCount, maxCount);
        }
        public Factorial TakeFactorial(EFunction eFunction)
        {
            var factorial = factorialPool.GetObject();            
            factorial.calcConfig.config = eFunction;
            return factorial;
        }

        public Fibonacci TakeFibonacci(EFunction eFunction)
        {
            var fibonacci = fibonnaciPool.GetObject();
            fibonacci.calcConfig.config = eFunction;
            return fibonacci;
        }

        public GDC2 TakeGDC2(EFunction eFunction)
        {
            var gdc2 = gdc2Pool.GetObject();
            gdc2.calcConfig.config = eFunction;
            return gdc2;
        }       
    }
}
