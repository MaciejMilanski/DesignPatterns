using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class ConsumerVisitor
    {
        public void Visit(Consumer consumer) 
        {
            consumer.BuyedProducts.AddRange(consumer.OrderList);
        }
    }
}
