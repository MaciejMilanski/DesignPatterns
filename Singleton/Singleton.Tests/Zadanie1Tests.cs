using System;
using System.Threading;

using Xunit;

using Zadanie1;

namespace Singleton.Tests
{
    public class Zadanie1Tests
    {
        [Fact]
        public void ChceckIfSameInstances()
        {
            s1CheckValue = "s1";
            s2CheckValue = "s2";
            Thread thread1 = new Thread(() =>
            {
                    MySingleton singleton1 = MySingleton.GetInstance("Foo");
                s1CheckValue = singleton1.Value;
            });
            Thread thread2 = new Thread(() =>
            {
                    MySingleton singleton2 = MySingleton.GetInstance("Bar");
                    s2CheckValue = singleton2.Value;

            });

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();

            Assert.Equal(s1CheckValue, s2CheckValue);            
            
          
        }
        public string s1CheckValue { get; set; }
        public string s2CheckValue { get; set; }
    }
}
