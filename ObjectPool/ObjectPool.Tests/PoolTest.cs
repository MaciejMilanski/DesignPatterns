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
            thread.Run(3, 10, EFunction.RECURSIVE);
            var factorialResult = thread.factorialTaskResult;
            var fibonacciResult = thread.fibonacciTaskResult;
            var gdc2Result = thread.gdc2TaskResult;

    
            Assert.Equal(6, factorialResult);

            Assert.Equal(2, fibonacciResult);
            
            Assert.Equal(1, gdc2Result);
            
        }
        [Fact]
        public void CheckIfCalculateIterative()
        {
            CalcThread thread = new CalcThread();
            thread.Run(3, 100, EFunction.ITERATIVE);
            var factorialResult = thread.factorialTaskResult;
            var fibonacciResult = thread.fibonacciTaskResult;
            var gdc2Result = thread.gdc2TaskResult;

            Assert.Equal(6, factorialResult);

            Assert.Equal(2, fibonacciResult);

            Assert.Equal(1, gdc2Result);
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
        [Fact]
        public void CheckIfSameInstances()
        {
            var prototypesManager = new PrototypesManager();
            var factorialInstance = prototypesManager.CreateFactorial();
            var fibonacciInstance = prototypesManager.CreateFibonacci();
            var gdc2Instance = prototypesManager.CreateGDC2();

            Assert.Equal(typeof(Factorial), factorialInstance.GetType());
            Assert.Equal(typeof(Fibonacci), fibonacciInstance.GetType());
            Assert.Equal(typeof(GDC2), gdc2Instance.GetType());
        }
        [Fact]
        public void CheckIfInstancesAreCorectlyBuild()
        {
            var builder = new CalcThreadBuilder(2, 8);
            var factorialRecursive = builder.TakeFactorial(EFunction.RECURSIVE);
            var fibonacciRecursive = builder.TakeFibonacci(EFunction.RECURSIVE);
            var gdc2Recursive = builder.TakeGDC2(EFunction.RECURSIVE);

            Assert.Equal(typeof(Factorial), factorialRecursive.GetType());
            Assert.Equal(typeof(Fibonacci), fibonacciRecursive.GetType());
            Assert.Equal(typeof(GDC2), gdc2Recursive.GetType());

            Assert.Equal(EFunction.RECURSIVE, factorialRecursive.calcConfig.config);
            Assert.Equal(EFunction.RECURSIVE, fibonacciRecursive.calcConfig.config);
            Assert.Equal(EFunction.RECURSIVE, gdc2Recursive.calcConfig.config);

            var factorialIterative = builder.TakeFactorial(EFunction.ITERATIVE);
            var fibonacciIterative = builder.TakeFibonacci(EFunction.ITERATIVE);
            var gdc2Iterative = builder.TakeGDC2(EFunction.ITERATIVE);

            Assert.Equal(typeof(Factorial), factorialIterative.GetType());
            Assert.Equal(typeof(Fibonacci), fibonacciIterative.GetType());
            Assert.Equal(typeof(GDC2), gdc2Iterative.GetType());

            Assert.Equal(EFunction.ITERATIVE, factorialIterative.calcConfig.config);
            Assert.Equal(EFunction.ITERATIVE, fibonacciIterative.calcConfig.config);
            Assert.Equal(EFunction.ITERATIVE, gdc2Iterative.calcConfig.config);
        }
    }
}

