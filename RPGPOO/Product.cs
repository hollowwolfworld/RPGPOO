using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEngine
{
    public class Product : Item
    {
        /// <summary>
        /// Le prix auquel l'objet est vendu
        /// </summary>
        public decimal Price { get; private set; }
        //public int Quantite { get; set; }

        //Création d'un article avec le nom de l'objet ainsi que sa description
        private Product(string name, string description, decimal price) : base(name, description)
        {
            Price = price;
        }

        /// <summary>
        /// Création d'un article avec un objet
        /// </summary>
        /// <param name="item">L'objet à transformer en article</param>
        /// <param name="prix">Le prix de vente de l'objet</param>
        public Product(Item item, decimal price) : this(item.Name, item.Description, price)
        {

        }
    }
}
