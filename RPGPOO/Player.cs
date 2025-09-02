using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public class Player : Entity
    {
        public int XP 
            { get; protected set; }

        public Inventory PlayerInventory;

        protected Player(int XP, int pv, int attaque, int defence, int levels, string nom) : base(pv, attaque, defence , levels, nom)
        {
            this.XP = XP;
            PlayerInventory = new Inventory(5);
        }

        public Player(string nom) : base(nom) 
        {

        }

    }
}
