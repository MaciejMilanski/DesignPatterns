using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public interface IObserver
    {
        void Update(Bank subject);
    }
}
