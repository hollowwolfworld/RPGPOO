using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO.Entities
{
    public class Player : Entity
    {
        public int XP { get; protected set; }

        public Inventory PlayerInventory;

        protected Player(int XP, int hp, int attack, int defence, int levels, string name) : base(hp, attack, defence , levels, name)
        {
            this.XP = XP;
            PlayerInventory = new Inventory(5);
        }

        public Player(string name) : base(name) 
        {
            XP = 0;
            Levels = 1;
        }


        public string Stats()
        {
            return "";
        }

    }
}
