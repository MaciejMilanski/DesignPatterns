using System;

using BenchmarkDotNet.Running;

namespace FactoryPattern.Banchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FactoriesBenchmark>();
        }
    }
}
