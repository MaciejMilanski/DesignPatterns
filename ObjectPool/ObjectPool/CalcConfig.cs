using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectPool
{
    public class CalcConfig
    {
        public CalcConfig() { }
        public CalcConfig(EFunction config)
        {
            this.config = config;
        }
        public EFunction config;
    }
}
