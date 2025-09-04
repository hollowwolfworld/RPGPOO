using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Inventories.Items
{
    public abstract class UsableItem: Item, Move
    {
        protected UsableItem(string name, string description) : base(name, description)
        {
        }

        public abstract void Use(IEntity on);
    }
}
