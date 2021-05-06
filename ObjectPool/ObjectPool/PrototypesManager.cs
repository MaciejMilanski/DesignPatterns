using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Interfaces;
using ObjectPool.Objects;

namespace ObjectPool
{
    public class PrototypesManager
    {
        private Dictionary<string, IAlgorithmObjectPrototype> objects = new Dictionary<string, IAlgorithmObjectPrototype>
        {
            {"Factorial", new Factorial()},
            {"Fibonacci", new Fibonacci()},
            {"GDC2", new GDC2()}
        };
        public Factorial CreateFactorial()
        {
            return (Factorial)objects["Factorial"].Clone();
        }
        public Fibonacci CreateFibonacci()
        {
            return (Fibonacci)objects["Fibonacci"].Clone();
        }
        public GDC2 CreateGDC2()
        {
            return (GDC2)objects["GDC2"].Clone();
        }

    }
}
