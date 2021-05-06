using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

using Zadanie2;

namespace Singleton.Tests
{
    public class Zadanie2Tests
    {
        [Fact]
        public void ChceckIfSameInstancesMethod1()
        {
            MySingleton1A s1A = MySingleton1<MySingleton1A>.GetInstance();
            MySingleton1A s2A = MySingleton1<MySingleton1A>.GetInstance();
            MySingleton1B s1B = MySingleton1<MySingleton1B>.GetInstance();
            MySingleton1B s2B = MySingleton1<MySingleton1B>.GetInstance();

            Assert.Equal(s1A, s2A);
            Assert.Equal(s1B, s2B);
        }
        [Fact]
        public void ChceckIfSameInstancesMethod2()
        {
            MySingleton2A s1 = MySingleton2A.GetInstance();
            MySingleton2A s2 = MySingleton2A.GetInstance();

            Assert.Equal(s1, s2);
        }

    }
}
