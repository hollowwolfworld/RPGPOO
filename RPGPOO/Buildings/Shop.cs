using EntityEngine.Entities.Players;
using EntityEngine.Exceptions;
using EntityEngine.Inventories.Items;
using RPGPOO.Exceptions;

namespace RPGPOO.Buildings
{
    public class Shop
    {
        private List<Product> Stock { get; set; }

        /// <summary>
        /// Création d'une boutique avec un stock déjà existant
        /// </summary>
        /// <param name="stock"></param>
        public Shop(List<Product> stock)
        {
            Stock = stock;
        }

        /// <summary>
        /// Constructeur pour crée une boutique avec un stock vide
        /// </summary>
        public Shop() : this([])
        {
        }

        /// <summary>
        /// Ajoute un article à la boutique
        /// </summary>
        /// <param name="product">L'article à ajouter</param>
        public void AddStock(Product product)
        {
            Stock.Add(product);
        }

        /// <summary>
        /// Retourne le stock de la boutique
        /// </summary>
        /// <returns>Stock de la boutique</returns>
        public IReadOnlyList<Product> GetStock()
        {
            return Stock;
        }

        /// <summary>
        /// Achat d'un article par le joueur
        /// </summary>
        /// <param name="name">Le nom éxacte de l'article</param>
        /// <param name="player">Le joueur qui achète l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as pas name comme nom</exception>
        /// <exception cref="NotEnoughtGoldException">Si le joueur n'as pas assez d'argent pour acheter cette article</exception>
        public void BuyArticle(string name, IPlayer player, int quantity)
        {
            var article = Stock.Find(x => x.item.Name == name);

            if (article == null) throw new ProductNotFoundException(name);

            if(article.Price * quantity > player.Gold) throw new NotEnoughtGoldException($"{article.Price * quantity} > {player.Gold}");

            player.Inventory.AddItem(article.item, quantity);
            player.Gold -= article.Price * quantity;
        }

        /// <summary>
        /// Vente d'un article par le joueur
        /// </summary>
        /// <param name="name">Le nom éxacte de l'article</param>
        /// <param name="player">Le joueur qui vend l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as ceci pour nom</exception>
        public void SellArticle(string name, IPlayer player, int quantity)
        {
            var article = Stock.Find(x => x.item.Name == name);

            if (article == null) throw new ProductNotFoundException(name);

            var item = player.Inventory.GetItemByName(name);

            if(item == null) throw new ProductNotFoundException(name);

            if(player.Inventory[item] < quantity) throw new NotEnoughtItem(name);

            player.Inventory.RemoveItem(item, quantity);
            player.Gold += article.Price * quantity;
        }

        /// <summary>
        /// Recherche un article par son nom
        /// </summary>
        /// <param name="name">Le nom de l'article</param>
        /// <returns>La liste d'article contenant dans leur nom le nom rechercher</returns>
        public List<Product> SearchArticle(string name) => Stock.FindAll((stock) => stock.item.Name == name);
    }
}
