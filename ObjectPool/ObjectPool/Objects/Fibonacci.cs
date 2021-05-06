using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Interfaces;

namespace ObjectPool.Objects
{
    public class Fibonacci : IAlgorithmObjectPrototype
    {
        public CalcConfig calcConfig;
        public Fibonacci() 
        {
            calcConfig = new CalcConfig();
        }
        public IAlgorithmObjectPrototype Clone()
        {
            Fibonacci clone = (Fibonacci)this.MemberwiseClone();
            //clone.calcConfig = new CalcConfig(calcConfig.config);
            return clone;
        }
        public int GetResult(int val)
        {
            if (calcConfig.config == EFunction.RECURSIVE)
                return GetRecursive(val);
            else
                return GetIterative(val);
        }
        int GetRecursive(int val)
        {
            if ((val == 1) || (val == 2))
                return 1;
            else
                return GetRecursive(val - 1) + GetRecursive(val - 2);
        }
        int GetIterative(int val)
        {
            int a = 0;
            int b = 1;
            for (int i = 0; i < val; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
    }
}
