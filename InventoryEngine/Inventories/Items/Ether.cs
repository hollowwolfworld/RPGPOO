using EntityEngine.Entities;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Inventories.Items
{
    public class Ether : UsableItem
    {
        public Ether(string name, string description, int restoreMana) : base(name, description)
        {
            RestoreMana = restoreMana;
        }
        public int RestoreMana { get; private set; }

        public override void Use(IEntity on)
        {
            if (on is not IMagical magical) throw new NotAMagicalEntity();
            magical.ManaPoint += RestoreMana;
        }
    }
}
