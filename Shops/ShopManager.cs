using System;
using System.Collections.Generic;
using System.Text;

namespace Shops
{
    public class ShopManager : IShopManager
    {
        private List<Shop> shops = new List<Shop>();

        public Shop Create(string name, string address)
        {
            var shop = new Shop(GetId(), name, address);
            shops.Add(shop);
            return shop;
        }

        public Product RegisterProduct(string name)
        {
            var product = new Product(name);
            return product;
        }

        public void ChangeCostProduct(Product product, Shop shop, decimal cost)
        {
            shop.ChangeCostProduct(product, cost);
        }

        public Shop FindCheapShop(List<Tuple<Product, int>> products)
        {
            Shop shop = null;
            decimal minTotal = int.MaxValue;

            foreach (Shop item in shops)
            {
                if (item.CheckProducts(products))
                {
                    decimal total = item.CalcCostProducts(products);
                    if (total < minTotal)
                    {
                        minTotal = total;
                        shop = item;
                    }
                }
            }

            return shop;
        }

        private int GetId()
        {
            if (shops.Count == 0)
                return 1;
            int maxId = 0;
            foreach (Shop shop in shops)
            {
                if (shop.Id > maxId)
                    maxId = shop.Id;
            }

            return maxId + 1;
        }
    }
}
