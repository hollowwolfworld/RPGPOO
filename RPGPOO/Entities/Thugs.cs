using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO.Entities
{
    internal class Thugs : Ennemy
    {
        protected Thugs(int hp, int attack, int defence, int levels, string name) : base(hp, attack, defence, levels, name)
        {
        }
    }
}
