using System;
using System.Collections.Generic;
using System.Text;

using ObjectPool.Interfaces;

namespace ObjectPool.Objects
{
    public class GDC2 : IAlgorithmObjectPrototype
    {
        public CalcConfig calcConfig;
        public GDC2() 
        {
            calcConfig = new CalcConfig();
        }
        public IAlgorithmObjectPrototype Clone()
        {
            GDC2 clone = (GDC2)this.MemberwiseClone();
            //clone.calcConfig = new CalcConfig(calcConfig.config);
            return clone;
        }
        public int GetResult(int val)
        {
            if (calcConfig.config == EFunction.RECURSIVE)
                return GetRecursive(val, 2);
            else
                return GetIterative(val, 2);
        }
        int GetRecursive(int a, int b)
        {

            if (b == 0)
            {
                return a;
            }
            else
            {
                return GetRecursive(b, a % b);
            }
        }
        int GetIterative(int a, int b)
        {
            int tmp;
            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }
    }
}
