using System;

using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace ObjectPool.Benchmark
{
    public class ObjectPoolBenchmark
    {
        #region THREADS10

        [Benchmark]
        public void B10Threads5Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 10, EFunction.ITERATIVE);

        }
        [Benchmark]
        public void B10Threads10Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 10, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B10Threads15Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 10, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B10Threads20Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 10, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B10Threads25Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 10, EFunction.ITERATIVE);
        }

        #endregion

        #region THREADS100

        [Benchmark]
        public void B100Threads5Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 100, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B100Threads10Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 100, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B100Threads15Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 100, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B100Threads20Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 100, EFunction.ITERATIVE);
        }
        [Benchmark]
        public void B100Threads25Objects()
        {
            CalcThread thread = new CalcThread();
            thread.Run(6, 100, EFunction.ITERATIVE);
        }

        #endregion
    }
}

