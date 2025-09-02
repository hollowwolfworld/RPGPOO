using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEngine.Entities.Enemies
{
    internal class Wizzard : Ennemy
    {
        protected Wizzard(int hp, int attack, int defence, int levels, string name) : base(hp, attack, defence, levels, name)
        {
        }
    }
}
