using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Shops.Tests
{
    public class ShopManagerTest
    {
        private ShopManager _shopManager;

        [SetUp]
        public void Setup()
        {
            _shopManager = new ShopManager();
        }

        [Test]
        public void BuyProducts()
        {
            decimal productCost = 50m;
            decimal balance = 1000;
            int productToBuyCount = 5;
            int productCount = 10;

            var person = new Person("Иван");
            person.Balance = balance;

            var shop = _shopManager.Create("Пятерочка", "москва мира 23 д.11");
            var product = _shopManager.RegisterProduct("молоко");

            var products = new List<Tuple<Product, int, decimal>>();
            products.Add(Tuple.Create(product, productCount, productCost));

            shop.AddProducts(products);
            shop.Buy(person, new List<Tuple<Product, int>>() { Tuple.Create(product, productToBuyCount) });

            Assert.AreEqual(balance - productCost * productToBuyCount, person.Balance);
            Assert.AreEqual(productCount - productToBuyCount, shop.GetProductInfo(product).Count);
        }
    }
}
