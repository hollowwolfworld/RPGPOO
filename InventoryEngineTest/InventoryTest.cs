using EntityEngine.Inventories;
using EntityEngine.Inventories.Items;

namespace InventoryEngineTest
{
    [TestClass]
    public sealed class InventoryTest
    {

        [DataTestMethod]
        [DataRow("TestItem", "TestItem", 1)]
        [DataRow("Potion", "Régénère votre personnage", 1)]
        [DataRow("Bomb", "Explose sur un énemie", 1)]
        public void AddOneItem(string name, string description, int expectedCount)
        {
            Item item = new Item(name, description);
            Inventory inventory = new Inventory(expectedCount);
            inventory.AddItem(item, 1);
            
            Assert.AreEqual(expectedCount, inventory.Size);
        }

        [DataTestMethod]
        [DataRow("TestItem", "TestItem", 99, 1, false)]
        [DataRow("Potion", "Régénère votre personnage", 1, 1, false)]
        [DataRow("Bomb", "Explose sur un énemie", 101, 1, true)]
        public void AddMultipleOfSameItem(string name, string description, int numberOfSameItemAdded, int expectedCount, bool raiseExpection)
        {
            Inventory inventory = new Inventory(expectedCount);
            Item item = new Item(name, description);
            try
            {
                for (int i = 0; i < numberOfSameItemAdded; i++)
                {
                    inventory.AddItem(new Item(name, description));
                }
            }
            catch (Exception)
            {
                Assert.IsTrue(raiseExpection);
            }

            Assert.IsTrue(expectedCount == inventory.Size && numberOfSameItemAdded == inventory.GetInventory()[item] && raiseExpection);
        }

        [TestMethod]
        public void NotEnoughPlace()
        {
            Inventory inventory = new Inventory(1);
            try
            {
                inventory.AddItem(new Item("TestItem", "TestItem"));
                inventory.AddItem(new Item("Potion", "Régénère votre personnage"));
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }
    }
}
