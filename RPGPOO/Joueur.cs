using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    internal class Joueur : Entite
    {
        public int XP 
            { get; protected set; }

        public Inventaire InventaireDuJoueur;

        public Joueur(int XP, int pv, int attaque, int defence, int levels, string nom) : base(pv, attaque, defence , levels, nom)
        {
            this.XP = XP;
            InventaireDuJoueur = new Inventaire(5);
        }


    }
}
