using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void ValidateCtorAndPrrp()
        {
            Shop shop = new Shop(12);
            Assert.IsNotNull(shop);

            Assert.Throws<ArgumentException>(() => new Shop(-4));
        }
        [Test]
        public void ValidateMethotAdd()
        {
            Shop shop = new Shop(3);
            Smartphone smartphone1 = new Smartphone("Nokia", 3000);
            Smartphone smartphone2 = new Smartphone("iPhone", 4500);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.AreEqual(2, shop.Count);

            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("iPhone", 45000)));

            shop.Add(new Smartphone("Samsung", 3200));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Huawei", 3200)));
        }
        [Test]
        public void ValidateMethotRemove()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Nokia", 3000);
            Smartphone smartphone2 = new Smartphone("iPhone", 4500);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Samsung"));

            shop.Remove("iPhone");
            Assert.AreEqual(1, shop.Count);
        }
        [Test]
        public void ValidateMethotTestPhone() 
        { 
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Nokia", 3000);
            Smartphone smartphone2 = new Smartphone("iPhone", 4500);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 500));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 3500));

            shop.TestPhone("Nokia", 2000);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia", 1254));

            Assert.AreEqual(1000, smartphone1.CurrentBateryCharge);
        }
        [Test]
        public void ValidateMethotChargePhone()
        {
            Shop shop = new Shop(2);
            Smartphone smartphone1 = new Smartphone("Nokia", 3000);
            Smartphone smartphone2 = new Smartphone("iPhone", 4500);

            shop.Add(smartphone1);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"));

            shop.TestPhone("iPhone", 2456);
            shop.ChargePhone("iPhone");

            Assert.AreEqual(smartphone2.MaximumBatteryCharge, smartphone2.CurrentBateryCharge);
        }

       
    }
}