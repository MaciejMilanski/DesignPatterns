using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Objects;

namespace ObjectPool
{
    public class CalcThread
    {
        private List<Factorial> factorialTask;
        private List<Fibonacci> fibonacciTask;
        private List<GDC2> gdc2Task;
        private PrototypesManager prototypesManager = new PrototypesManager();
        private CalcThreadBuilder builder = new CalcThreadBuilder(2,8);
        public CalcThread() 
        {
            factorialTask = new List<Factorial>();
            fibonacciTask = new List<Fibonacci>();
            gdc2Task = new List<GDC2>();
        }
        public void AddTask(Factorial factorial) 
        {
            factorialTask.Add(factorial);
        }
        public void AddTask(Fibonacci fibonacci) 
        {
            fibonacciTask.Add(fibonacci);
        }
        public void AddTask(GDC2 gdc2)
        {
            gdc2Task.Add(gdc2);
        }
        public void Run(int val, int threads, EFunction mode) 
        {
            Parallel.For(0, threads, (i, loopState) =>
            {
                var factorialCalc = builder.TakeFactorial(mode);
                factorialTaskResult = factorialCalc.GetResult(val);
                FactorialPool.GetInstance(prototypesManager.CreateFactorial, 2, 5).PutObject(factorialCalc);
            });
            Parallel.For(0, threads, (i, loopState) =>
            {
                var fibonacciCalc = builder.TakeFibonacci(mode);
                fibonacciTaskResult = fibonacciCalc.GetResult(val);
                FibonnaciPool.GetInstance(prototypesManager.CreateFibonacci, 2, 5).PutObject(fibonacciCalc);
            });
            Parallel.For(0, threads, (i, loopState) =>
            {
                var gdc2Calc = builder.TakeGDC2(mode);
                gdc2TaskResult = gdc2Calc.GetResult(val);
                GDC2Pool.GetInstance(prototypesManager.CreateGDC2, 2, 5).PutObject(gdc2Calc);
            });
        }
        public int factorialTaskResult { get; set; }
        public int fibonacciTaskResult { get; set; }
        public int gdc2TaskResult { get; set; }
    }
}
