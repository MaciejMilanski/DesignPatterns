using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

using ObjectPool.Objects;

namespace ObjectPool.Tests
{
    public class PoolTest
    {
        private static readonly object _lock = new object();
        [Fact]
        public void CheckIfCalculateRecursive()
        {
            CalcThread thread = new CalcThread();
            CalcThreadBuilder builder = new CalcThreadBuilder();
            thread.Run(3, 5, EFunction.RECURSIVE);
            var factorialResult = thread.factorialTaskResults;
            var fibonacciResult = thread.fibonacciTaskResults;
            var gdc2Result = thread.gdc2TaskResults;

            foreach (var result in factorialResult) 
            {
                Assert.Equal(6, result);
            }
            foreach (var result in fibonacciResult)
            {
                Assert.Equal(2, result);
            }
            foreach (var result in gdc2Result)
            {
                Assert.Equal(1, result);
            }
        }
        [Fact]
        public void CheckIfCalculateIterative()
        {
            CalcThread thread = new CalcThread();
            CalcThreadBuilder builder = new CalcThreadBuilder();
            thread.Run(3, 5, EFunction.ITERATIVE);
            var factorialResult = thread.factorialTaskResults;
            var fibonacciResult = thread.fibonacciTaskResults;
            var gdc2Result = thread.gdc2TaskResults;

            foreach (var result in factorialResult)
            {
                Assert.Equal(6, result);
            }
            foreach (var result in fibonacciResult)
            {
                Assert.Equal(2, result);
            }
            foreach (var result in gdc2Result)
            {
                Assert.Equal(1, result);
            }
        }
        [Fact]
        public void CheckPoolObjectsCounts() 
        {
            int minCount = 2;
            int maxCount = 8;
            var prototypesManager = new PrototypesManager();


            var factorialPool = FactorialPool.GetInstance(prototypesManager.CreateFactorial, minCount, maxCount);
            Assert.True(factorialPool.GetCount() >= minCount);
            for (int i = 0; i < maxCount + 10; i++)
                factorialPool.PutObject(prototypesManager.CreateFactorial());
            Assert.True(factorialPool.GetCount() <= maxCount);


            var fibonacciPool = FibonnaciPool.GetInstance(prototypesManager.CreateFibonacci, minCount, maxCount);
            Assert.True(fibonacciPool.GetCount() >= minCount);
            for (int i = 0; i < maxCount + 10; i++)
                fibonacciPool.PutObject(prototypesManager.CreateFibonacci());
            Assert.True(fibonacciPool.GetCount() <= maxCount);


            var gdc2Pool = GDC2Pool.GetInstance(prototypesManager.CreateGDC2, minCount, maxCount);
            Assert.True(gdc2Pool.GetCount() >= minCount);
            for (int i = 0; i < maxCount + 10; i++)
                gdc2Pool.PutObject(prototypesManager.CreateGDC2());
            Assert.True(gdc2Pool.GetCount() <= maxCount);

        }
    }
}
//TODO testy prototypów
//TODO testy budowniczych
//TODO testy dodawania odejmowania elementów.
//TODO benchmark dla niewielu w¹tków i 5 ró¿nych maksymalnych wielkoœci puli. 5,10,15,20,25 obiektów
//TODO benchmark dla wielu w¹tków i 5 ró¿nych maksymalnych wielkoœci puli. 5,10,15,20,25 obiektów
