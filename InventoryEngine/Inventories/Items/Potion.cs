using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Inventories.Items
{
    public class Potion: UsableItem
    {
        public Potion(string name, string description, int restoreHealth) : base(name, description)
        {
            RestoreHealth = restoreHealth;
        }

        public Potion(Potion potion) : this(potion.Name, potion.Description, potion.RestoreHealth) { }

        public int RestoreHealth { get; private set; }

        public override void Use(IEntity on)
        {
            on.HealthPoint += RestoreHealth;
        }
    }
}
