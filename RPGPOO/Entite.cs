using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal abstract class Entite
    {
        protected int PV;
        protected int Attaque;
        protected int Defence;
        protected int Levels;
        protected string Nom;

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
