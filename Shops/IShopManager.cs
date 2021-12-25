using System;
using System.Collections.Generic;
using System.Text;

namespace Shops
{
    public interface IShopManager
    {
        Shop Create(string name, string address);
        Product RegisterProduct(string name);
    }
}
