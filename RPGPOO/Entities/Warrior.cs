using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO.Entities
{
    internal class Warrior : Player
    {
        protected Warrior(int XP, int hp, int attack, int defence, int levels, string name) : base(XP ,hp, attack, defence, levels, name)
        {

        }

        public Warrior (string name) : base(name) 
        {

        }
    }
}
