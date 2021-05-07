using System;

using ObjectPool.Interfaces;

namespace ObjectPool.Objects
{
    public class Factorial : IAlgorithmObjectPrototype
    {
        public CalcConfig calcConfig;
        public Factorial() 
        {
            calcConfig = new CalcConfig();
        }
        public IAlgorithmObjectPrototype Clone()
        {
            Factorial clone = (Factorial)this.MemberwiseClone();
            //clone.calcConfig = new CalcConfig(calcConfig.config);//TODO Czy to napewno deepkopia?
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
            if (val == 0)
            {
                return 1;
            }
            return val * GetRecursive(val - 1);
        }

        int GetIterative(int val)
        {
            int res = 1;
            while (val != 1)
            {
                res = res * val;
                val = val - 1;
            }
            return res;
        }
    }
}
