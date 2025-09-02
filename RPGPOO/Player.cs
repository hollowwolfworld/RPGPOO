using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public class Player : Entite
    {
        public int XP 
            { get; protected set; }

        public Inventaire PlayerInventory;

        protected Player(int XP, int pv, int attaque, int defence, int levels, string nom) : base(pv, attaque, defence , levels, nom)
        {
            this.XP = XP;
            PlayerInventory = new Inventaire(5);
        }

        public Player(string nom) : base(nom) 
        {

        }

    }
}
