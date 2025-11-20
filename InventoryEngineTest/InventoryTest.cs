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
                return;
            }

            var item = inventory.GetItemByName(name);

            if (item == null)
            {
                Assert.Fail();
                return;
            }

            Assert.IsTrue(expectedCount == inventory.Size && numberOfSameItemAdded == inventory[item] && !raiseExpection);
        }

        [DataTestMethod]
        [DataRow(3, 1, 3, 1)]
        [DataRow(3, 1, 9, 1)]
        [DataRow(3, 1, 3, 9)]
        [DataRow(4, 1, 3, 1)]
        [DataRow(3, 5, 3, 1)]
        public void AddDifferentItem(int numberOfDifferentItem, int numberOfItemBySlot, int inventorySize, int inventorySlotSize)
        {
            bool expectExeption = inventorySize < numberOfDifferentItem || inventorySlotSize < numberOfItemBySlot;
            Inventory inventory = new Inventory(inventorySize, inventorySlotSize);

            try
            {
                for (int i = 0; i < numberOfDifferentItem; i++)
                {
                    Item item = new Item($"{i}", $"{i}");
                    for (int j = 0; j < numberOfItemBySlot; j++)
                    {
                        inventory.AddItem(item);
                    }
                }
            }
            catch (Exception)
            {
                Assert.IsTrue(expectExeption);
                return;
            }

            Assert.IsTrue(!expectExeption && inventory.Size == numberOfDifferentItem && inventory.First().Value == numberOfItemBySlot);
        }

        [DataTestMethod]
        [DataRow(10, 10)]
        [DataRow(10, 11)]
        [DataRow(11, 10)]
        public void NotEnoughPlace(int numberOfItem, int numberOfItemToRemove)
        {
            bool raiseException = numberOfItem < numberOfItemToRemove;
            Inventory inventory = new Inventory(1, numberOfItem);
            Item testItem = new Item("TestItem", "TestItem");

            inventory.AddItem(testItem, numberOfItem);

            try
            {
                inventory.RemoveItem(testItem, numberOfItemToRemove);
            }
            catch (Exception)
            {
                Assert.IsTrue(raiseException);
                return;
            }

            if (inventory[testItem] == -1) 
                Assert.IsTrue(!raiseException && inventory[testItem] + 1 == numberOfItem - numberOfItemToRemove);
            else 
                Assert.IsTrue(!raiseException && (inventory[testItem] == numberOfItem - numberOfItemToRemove));
        }
    }
}
