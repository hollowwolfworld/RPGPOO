using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal abstract class Entite
    {
        public int PV { get; protected set; }
        public int Attaque { get; protected set; }
        public int Defence { get; protected set; }
        public int Levels { get; protected set; }
        public string Nom { get; protected set;  }

       protected Entite(int pv,int attaque,int defence, int levels,string nom)
        {
            PV = pv;
            Attaque = attaque;
            Defence = defence;
            Levels = levels;
            Nom = nom;
        }

        public Entite(string nom)
        {
            Nom = nom;
        }


    }
}
