using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Sorcerer : Player
    {
        protected Sorcerer(int XP, int hp, int attack, int defence, int levels, string name) : base(XP, hp, attack, defence, levels, name)
        {

        }
    }
}
