using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities
{
    public abstract class MagicalEntity : Entity
    {
        public int ManaPoint { get; private set; }
        protected MagicalEntity(int healthPoint, int attack, int defence, int manaPoint, int levels, string name) : base(healthPoint, attack, defence, levels, name)
        {
            ManaPoint = manaPoint;
        }
    }
}
