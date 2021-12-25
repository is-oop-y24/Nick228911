using System;
using System.Collections.Generic;
using System.Text;

namespace Shops
{
    public class ProductItem
    {
        public ProductItem(Product product, int count, decimal cost)
        {
            Product = product;
            Count = count;
            Cost = cost;
        }

        public Product Product { get; }
        public int Count { get; set; }
        public decimal Cost { get; set; }
    }
}
