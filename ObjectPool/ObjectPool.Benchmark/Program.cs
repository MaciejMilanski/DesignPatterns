using System;

using BenchmarkDotNet.Running;
using ObjectPool.Benchmark;

namespace ObjectPool.Banchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ObjectPoolBenchmark>();
        }
    }
}
