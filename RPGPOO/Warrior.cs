using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal class Warrior : Player
    {
        protected Warrior(int XP, int pv, int attaque, int defence, int levels, string nom) : base(XP ,pv, attaque, defence, levels, nom)
        {

        }

        public Warrior (string nom) : base(nom) 
        {

        }
    }
}
