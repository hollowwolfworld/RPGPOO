using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public abstract class Entite
    {
        public int PV { get; private set; }
        public int Attaque { get; private set; }
        public int Defence { get; private set; }
        public int Levels { get; private set; }
        public string Nom { get; private set;  }

       protected Entite(int pv,int attaque,int defence, int levels,string nom)
        {
            PV = pv;
            Attaque = attaque;
            Defence = defence;
            Levels = levels;
            Nom = nom;
        }


    }
}
