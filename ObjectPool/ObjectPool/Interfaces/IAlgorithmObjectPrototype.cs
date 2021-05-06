using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectPool.Interfaces
{
    public interface IAlgorithmObjectPrototype
    {
        IAlgorithmObjectPrototype Clone();
        int GetResult(int val);       
    }
}
