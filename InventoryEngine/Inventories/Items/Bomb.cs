using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Inventories.Items
{
    public class Bomb : UsableItem
    {
        public Bomb(string name, string description, int explosionDamage) : base(name, description)
        {
            ExplosionDamage = explosionDamage;
        }

        public int ExplosionDamage { get; private set; }

        public override void Use(IEntity on)
        {
            on.HealthPoint -= ExplosionDamage;
        }
    }
}
