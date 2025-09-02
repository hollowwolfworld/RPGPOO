using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPOO
{
    public class Inventaire
    {
        /// <summary>
        /// Nombre maximum d'item que le joueur peut mettre dans son inventaire
        /// </summary>
        public int Taille {  get; private set; }
        /// <summary>
        /// Une collection d'Item avec leur quantité
        /// </summary>
        private Dictionary<Item, int> Items { get; set; }

        /// <summary>
        /// Crée un inventaire avec un dictionnaire contenant déjà des items ainsi qu'une taille
        /// </summary>
        /// <param name="taille">La taille de l'inventaire</param>
        /// <param name="item">Les items présent par </param>
        public Inventaire(int taille, Dictionary<Item, int> items)
        {
            Taille = taille;
            Items = items;
        }

        /// <summary>
        /// Crée un inventaire vide avec une taille
        /// </summary>
        /// <param name="taille">La taille de l'inventaire</param>
        public Inventaire(int taille)
        {
            Taille = taille;
            Items = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Ajoute un objet ainsi que la quantité à ajouter
        /// </summary>
        /// <param name="item">L'objet à ajouter à l'inventaire</param>
        /// <param name="quantity">La quantité de l'objet à ajouter</param>
        public void AddItem(Item item, int quantity)
        {

        }

        /// <summary>
        /// Enlève une certaine quantité d'un objet à l'inventaire
        /// </summary>
        /// <param name="item">L'objet à enlever</param>
        /// <param name="quantity">La quantité à enlever</param>
        public void RemoveItem(Item item, int quantity)
        {

        }

        /// <summary>
        /// Recherche l'objet et sa quantité avec son nom
        /// </summary>
        /// <param name="name">Le nom de l'objet</param>
        /// <returns>La liste des objets trouver contenant ce nom avec leur quantité dans l'inventaire</returns>
        public Dictionary<Item, int> SearchItem(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Récupère l'inventaire dans son entierter
        /// </summary>
        /// <returns>Les objets avec leur quantités</returns>
        public Dictionary<Item, int> GetInventory()
        {
            return Items;
        }
    }
}
