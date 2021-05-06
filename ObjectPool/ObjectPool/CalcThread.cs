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
        private CalcThreadBuilder builder = new CalcThreadBuilder();
        public CalcThread() 
        {
            factorialTask = new List<Factorial>();
            fibonacciTask = new List<Fibonacci>();
            gdc2Task = new List<GDC2>();
            factorialTaskResults = new List<int>();
            fibonacciTaskResults = new List<int>();
            gdc2TaskResults = new List<int>();
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
        public void Run(int val, int iter, EFunction mode) 
        {
            Parallel.For(0, iter, (i, loopState) =>
            {
                var factorialCalc = builder.TakeFactorial(mode);
                factorialTaskResults.Add(factorialCalc.GetResult(val));
                FactorialPool.GetInstance(prototypesManager.CreateFactorial, 2, 8).PutObject(factorialCalc);
            });
            Parallel.For(0, iter, (i, loopState) =>
            {
                var fibonacciCalc = builder.TakeFibonacci(mode);
                fibonacciTaskResults.Add(fibonacciCalc.GetResult(val));
                FibonnaciPool.GetInstance(prototypesManager.CreateFibonacci, 2, 8).PutObject(fibonacciCalc);
            });
            Parallel.For(0, iter, (i, loopState) =>
            {
                var gdc2Calc = builder.TakeGDC2(mode);
                gdc2TaskResults.Add(gdc2Calc.GetResult(val));
                GDC2Pool.GetInstance(prototypesManager.CreateGDC2, 2, 8).PutObject(gdc2Calc);
            });
        }
        //public void ReleseObjects(GenericPool<Factorial> factorialPool, GenericPool<Fibonacci> fibonacciPool, GenericPool<GDC2> gdc2Pool) 
        //{
        //    factorialPool.PutObject(_factorial);
        //    fibonacciPool.PutObject(_fibonacci);
        //    gdc2Pool.PutObject(_gdc2);
        //}
        public List<int> factorialTaskResults { get; set; }
        public List<int> fibonacciTaskResults { get; set; }
        public List<int> gdc2TaskResults { get; set; }
    }
}
