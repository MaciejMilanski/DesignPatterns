using System;
using System.Collections.Generic;
using System.Text;

namespace RegulatedMarket
{
    public class SellerVisitor
    {
        public void Visit(Seller seller) 
        {
            foreach (var productToRemove in seller.OrderList)
            {
                seller.Products.Remove(productToRemove);
                seller.ProductPrices.RemoveAll(x => x.Product.Guid == productToRemove.Guid);
            }
        }
    }
}
