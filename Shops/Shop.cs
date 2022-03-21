using System;
using System.Collections.Generic;
using System.Text;

namespace Shops
{
    public class Shop
    {
        private int id;
        private string name;
        private string address;
        private List<ProductItem> productItems = new List<ProductItem>();

        public Shop(int id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public int Id => id;
        public string Name => name;
        public string Address => address;

        public void AddProducts(List<Tuple<Product, int, decimal>> listProducts)
        {
            foreach (Tuple<Product, int, decimal> item in listProducts)
            {
                ProductItem productItem = GetProductInfo(item.Item1);
                if (productItem != null)
                {
                    productItem.Count += item.Item2;
                    productItem.Cost = item.Item3;
                }
                else
                {
                    productItem = new ProductItem(item.Item1, item.Item2, item.Item3);
                    productItems.Add(productItem);
                }
            }
        }

        public void ChangeCostProduct(Product product, decimal cost)
        {
            var productItem = GetProductInfo(product);
            if (productItem == null)
                throw new ArgumentException($"Нет товара: {product.Name}");
            productItem.Cost = cost;
        }

        public bool CheckProducts(List<Tuple<Product, int>> products)
        {
            foreach (Tuple<Product, int> item in products)
            {
                ProductItem productItem = GetProductInfo(item.Item1);
                if (productItem == null || productItem.Count < item.Item2)
                    return false;
            }

            return true;
        }

        public decimal CalcCostProducts(List<Tuple<Product, int>> products)
        {
            decimal totalMoney = 0;
            foreach (Tuple<Product, int> item in products)
            {
                ProductItem productItem = GetProductInfo(item.Item1);
                totalMoney += item.Item2 * productItem.Cost;
            }

            return totalMoney;
        }

        public void Buy(Person person, List<Tuple<Product, int>> products)
        {
            decimal totalMoney = 0;
            foreach (Tuple<Product, int> item in products)
            {
                ProductItem productItem = GetProductInfo(item.Item1);
                if (productItem == null)
                {
                    throw new ArgumentException($"Нет товара: {item.Item1.Name}");
                }

                if (productItem.Count < item.Item2)
                {
                    throw new ArgumentException($"Недостаточное кол-во товара: {item.Item1.Name}");
                }

                totalMoney += item.Item2 * productItem.Cost;
            }

            if (totalMoney > person.Balance)
            {
                throw new ArgumentException("Недостаточно средств");
            }

            foreach (Tuple<Product, int> item in products)
            {
                ProductItem productItem = GetProductInfo(item.Item1);
                productItem.Count -= item.Item2;
            }

            person.Balance -= totalMoney;
        }

        public ProductItem GetProductInfo(Product product)
        {
            foreach (ProductItem item in productItems)
            {
                if (item.Product == product)
                    return item;
            }

            return null;
        }
    }
}
