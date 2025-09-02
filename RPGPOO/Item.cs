using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public abstract class Item
    {
        public string Nom { get; set; }
        public string Description { get; set; }

        protected Item(string nom, string description)
        {
            Nom = nom;
            Description = description;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
