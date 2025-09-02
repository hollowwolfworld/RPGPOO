using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    class Inventaire
    {
        public int Taille {  get; private set; }
        private Dictionary<Item, int> Item { get; set; }

        public Inventaire(int taille, Dictionary<Item, int> item)
        {
            Taille = taille;
            Item = item;
        }

        public Inventaire(int taille)
        {
            Taille = taille;
            Item = new Dictionary<Item, int>();
        }

        public void AddItem(Item item, int quantity)
        {

        }

        public void RemoveItem(Item item, int quantity)
        {

        }

        public Item GetItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
