using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Xunit;

using Zadanie3;

namespace Singleton.Tests
{
    public class Zadanie3Tests
    {
        [Fact]
        public void ChceckIfSameInstances()
        {
            MySingleton singletonBefore = MySingleton.GetInstance();

            MemoryStream stream = MySingleton.intoStream(singletonBefore);
            MySingleton singletonAfter = MySingleton.intoObject(stream);

            Assert.Equal(singletonBefore, singletonAfter);
        }
    }
}
