using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal class Sorcerer : Joueur
    {
        protected Sorcerer(int XP, int pv, int attaque, int defence, int levels, string nom) : base(XP, pv, attaque, defence, levels, nom)
        {

        }

        public Sorcerer(string nom) : base(nom)
        {

        }
    }
}
