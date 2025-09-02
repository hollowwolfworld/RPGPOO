using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEngine.Items
{
    public class Potion: Item
    {
        public Potion(string name, string description, int restoreHealth) : base(name, description)
        {
            RestoreHealth = restoreHealth;
        }

        public Potion(Potion potion) : this(potion.Name, potion.Description, potion.RestoreHealth) { }

        public int RestoreHealth { get; private set; }
    }
}
