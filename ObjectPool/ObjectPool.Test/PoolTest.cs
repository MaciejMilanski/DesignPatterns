using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObjectPool.Test
{
    [Fact]
    public class PoolTest
    {
        [TestMethod]
        public void CheckIfCalculate()
        {
            Factorial factorial = new Factorial();
            Fibonacci fibonacci = new Fibonacci();
            GDC2 gdc2 = new GDC2();
            GenericPool<Factorial> factorialPool = new GenericPool<Factorial>(() => (Factorial)factorial.clone());
            GenericPool<Fibonacci> fibonacciPool = new GenericPool<Fibonacci>(() => (Fibonacci)fibonacci.clone());
            GenericPool<GDC2> gdc2Pool = new GenericPool<GDC2>(() => (GDC2)gdc2.clone());
            CalcThreadBuilder builder = new CalcThreadBuilder();
            builder.TakeFactorial(factorialPool.GetObject(), EFunction.RECURSIVE);
            builder.TakeFibonacci(fibonacciPool.GetObject(), EFunction.RECURSIVE);
            builder.TakeGDC2(gdc2Pool.GetObject(), EFunction.RECURSIVE);
            CalcThread calcThread = builder.GetThread();

            int equals = 6;
            int result = calcThread.Result(2);
            calcThread.ReleseObjects(factorialPool, fibonacciPool, gdc2Pool);
            Assert.AreEqual(equals, result);

        }
    }
}
