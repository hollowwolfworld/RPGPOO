using InventoryEngine.Exceptions;
using InventoryEngine.Items;

namespace InventoryEngine
{
    public class Inventory
    {
        /// <summary>
        /// Nombre maximum d'item que le joueur peut mettre dans son inventaire
        /// </summary>
        public int Size { get; private set; }
        /// <summary>
        /// Une collection d'Item avec leur quantité
        /// </summary>
        private Dictionary<Item, int> Items { get; set; }

        /// <summary>
        /// Crée un inventaire avec un dictionnaire contenant déjà des items ainsi qu'une taille
        /// </summary>
        /// <param name="size">La taille de l'inventaire</param>
        /// <param name="item">Les items présent par </param>
        public Inventory(int size, Dictionary<Item, int> items)
        {
            Size = size;
            Items = items;
        }

        /// <summary>
        /// Crée un inventaire vide avec une taille
        /// </summary>
        /// <param name="size">La taille de l'inventaire</param>
        public Inventory(int size)
        {
            Size = size;
            Items = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Ajoute un objet ainsi que la quantité à ajouter
        /// </summary>
        /// <param name="item">L'objet à ajouter à l'inventaire</param>
        /// <param name="quantity">La quantité de l'objet à ajouter</param>
        public void AddItem(Item item, int quantity)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += quantity;
                return;
            }

            if (Items.Count == Size) return;

            Items.Add(item, quantity);
        }

        /// <summary>
        /// Enlève une certaine quantité d'un objet à l'inventaire
        /// </summary>
        /// <param name="item">L'objet à enlever</param>
        /// <param name="quantity">La quantité à enlever</param>
        /// <exception cref="NotEnoughtItem">Si il n'y a pas assez d'item dans l'inventaire pour en retirer cette quantité</exception>
        public void RemoveItem(Item item, int quantity)
        {
            if (!Items.ContainsKey(item))
            {
                throw new ItemNotFound();
            }

            if (quantity > Items[item])
            {
                throw new NotEnoughtItem();
            }
            else if (quantity == Items[item])
            {
                Items.Remove(item);
            }
            else
            {
                Items[item] -= quantity;
            }
        }

        /// <summary>
        /// Recherche l'objet et sa quantité avec son nom
        /// </summary>
        /// <param name="name">Le nom de l'objet</param>
        /// <returns>La liste des objets trouver contenant ce nom avec leur quantité dans l'inventaire</returns>
        public Dictionary<Item, int> SearchItem(string name)
        {
            Dictionary<Item, int> found = new Dictionary<Item, int>();

            foreach (var keyValuePair in Items)
            {
                if (keyValuePair.Key.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) found.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return found;
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
