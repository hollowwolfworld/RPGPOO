using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal class Slime : Ennemy
    {
        protected Slime(int pv, int attaque, int defence, int levels, string nom) : base(pv, attaque, defence, levels, nom)
        {
        }
    }
}
