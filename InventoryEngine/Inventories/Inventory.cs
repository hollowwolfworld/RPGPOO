using EntityEngine.Exceptions;
using EntityEngine.Inventories.Items;

namespace EntityEngine.Inventories
{
    public class Inventory
    {
        /// <summary>
        /// Retourne le nombre d'item différent dans l'inventaire
        /// </summary>
        public int Size { get { return Items.Count; } }

        /// <summary>
        /// The maximum number of the same type of item you can have in an inventory
        /// </summary>
        public int MaxSlotSize { get; private set; }
        
        /// <summary>
        /// Nombre maximum d'item que le joueur peut mettre dans son inventaire
        /// </summary>
        public int MaxSize { get; private set; }

        /// <summary>
        /// Une collection d'Item avec leur quantité
        /// </summary>
        private Dictionary<Item, int> Items { get; set; }

        /// <summary>
        /// Crée un inventaire avec un dictionnaire contenant déjà des items ainsi qu'une taille
        /// </summary>
        /// <param name="size">La taille de l'inventaire</param>
        /// <param name="item">Les items présent par </param>
        public Inventory(int size, Dictionary<Item, int> items, int maxSlotSize = 100)
        {
            MaxSlotSize = maxSlotSize;
            MaxSize = size;
            Items = items;
        }

        /// <summary>
        /// Crée un inventaire vide avec une taille
        /// </summary>
        /// <param name="size">La taille de l'inventaire</param>
        public Inventory(int size, int maxSlotSize = 100)
        {
            MaxSlotSize = maxSlotSize;
            MaxSize = size;
            Items = new Dictionary<Item, int>();
        }

        /// <summary>
        /// Ajoute un objet ainsi que la quantité à ajouter
        /// </summary>
        /// <param name="item">L'objet à ajouter à l'inventaire</param>
        /// <param name="quantity">La quantité de l'objet à ajouter</param>
        public void AddItem(Item item, int quantity = 1)
        {
            Item? itemInDictionnary = GetItemByName(item.Name);
            if (itemInDictionnary != null)
            {
                if (Items[itemInDictionnary] == MaxSlotSize) throw new NotEnoughtPlace();
                Items[itemInDictionnary] += quantity;
                return;
            }

            if (Items.Count == Size) throw new NotEnoughtPlace();

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
            Item? itemInDictionnary = GetItemByName(item.Name);
            if (itemInDictionnary == null)
            {
                throw new ItemNotFound();
            }

            if (quantity > Items[itemInDictionnary])
            {
                throw new NotEnoughtItem();
            }
            else if (quantity == Items[itemInDictionnary])
            {
                Items.Remove(itemInDictionnary);
            }
            else
            {
                Items[itemInDictionnary] -= quantity;
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

        /// <summary>
        /// Récuper l'objet avec son nom
        /// </summary>
        /// <param name="name">Le nom de l'objet</param>
        /// <returns>Retourne null si l'objet n'est pas retrouvez sinon il retourne l'objet</returns>
        private Item? GetItemByName(string name)
        {
            foreach (var keyValuePair in Items)
            {
                if (keyValuePair.Key.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) return keyValuePair.Key;
            }
            return null;
        }
    }
}
