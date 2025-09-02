using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightEngine.Entities.Players;
using InventoryEngine.Exceptions;

namespace RPGPOO.Buildings
{
    public class Shop
    {
        public List<Product> Stock { get; set; }

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
            
        }

        /// <summary>
        /// Retourne le stock de la boutique
        /// </summary>
        /// <returns>Stock de la boutique</returns>
        public List<Product> GetStock()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Achat d'un article par le joueur
        /// </summary>
        /// <param name="name">Le nom éxacte de l'article</param>
        /// <param name="player">Le joueur qui achète l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as ceci pour nom</exception>
        public void BuyArticle(string name, Player player)
        {

        }

        /// <summary>
        /// Vente d'un article par le joueur
        /// </summary>
        /// <param name="name">Le nom éxacte de l'article</param>
        /// <param name="player">Le joueur qui vend l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as ceci pour nom</exception>
        public void SellArticle(string nom, Player player)
        {

        }

        /// <summary>
        /// Recherche un article par son nom
        /// </summary>
        /// <param name="name">Le nom de l'article</param>
        /// <returns>La liste d'article contenant dans leur nom le nom rechercher</returns>
        public List<Product> SearchArticle(string name)
        {
            throw new NotImplementedException();
        }
    }
}
