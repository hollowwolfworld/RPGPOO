using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public class Product : Item
    {
        /// <summary>
        /// Le prix auquel l'objet est vendu
        /// </summary>
        public decimal Prix { get; private set; }
        //public int Quantite { get; set; }

        //Création d'un article avec le nom de l'objet ainsi que sa description
        private Product(string nom, string description, decimal prix) : base(nom, description)
        {
            Prix = prix;
        }

        /// <summary>
        /// Création d'un article avec un objet
        /// </summary>
        /// <param name="item">L'objet à transformer en article</param>
        /// <param name="prix">Le prix de vente de l'objet</param>
        public Product(Item item, decimal prix) : this(item.Nom, item.Description, prix)
        {

        }
    }
}
