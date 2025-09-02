using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal class Thieft : Joueur
    {
        protected Thieft(int XP, int pv, int attaque, int defence, int levels, string nom) : base(XP, pv, attaque, defence, levels, nom)
        {

        }

        public Thieft(string nom) : base(nom)
        {

        }
    }
}
