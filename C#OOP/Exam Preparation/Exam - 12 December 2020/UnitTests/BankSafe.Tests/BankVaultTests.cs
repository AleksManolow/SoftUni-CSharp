using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [Test]
        public void ValidateCtor()
        {
            BankVault bankVault = new BankVault();
            Assert.IsNotNull(bankVault);
        }
        [Test]
        public void ValidateAddItem() 
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Gosho", "123ID");

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("C5", item));

            Assert.AreEqual("Item:123ID saved successfully!", bankVault.AddItem("C4", item));

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("C4", new Item("Pesho", "7894")));

            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("C2", new Item("Kire", "123ID")));

            Assert.AreEqual(item, bankVault.VaultCells["C4"]);
        }
        [Test]
        public void ValidateRemoveItem() 
        {
            BankVault bankVault = new BankVault();
            Item item1 = new Item("Gosho", "123ID");
            Item item2 = new Item("Gosho", "1237ID");


            bankVault.AddItem("C4", item1);
            bankVault.AddItem("C3", item2);


            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("C5", item1));

            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("C3", item1));

            Assert.AreEqual("Remove item:123ID successfully!", bankVault.RemoveItem("C4", item1));
        }
    }
}