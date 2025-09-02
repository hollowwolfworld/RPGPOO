using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGPOO.Exceptions;

namespace RPGPOO
{
    public class Shop
    {
        public List<Article> Stock { get; set; }

        /// <summary>
        /// Création d'une boutique avec un stock déjà existant
        /// </summary>
        /// <param name="stock"></param>
        public Shop(List<Article> stock)
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
        /// <param name="article">L'article à ajouter</param>
        public void AddStock(Article article)
        {
            
        }

        /// <summary>
        /// Retourne le stock de la boutique
        /// </summary>
        /// <returns>Stock de la boutique</returns>
        public List<Article> GetStock()
        {
            return Stock;
        }

        /// <summary>
        /// Achat d'un article par le joueur
        /// </summary>
        /// <param name="nom">Le nom éxacte de l'article</param>
        /// <param name="joueur">Le joueur qui achète l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as ceci pour nom</exception>
        public void BuyArticle(String nom, Joueur joueur)
        {

        }

        /// <summary>
        /// Vente d'un article par le joueur
        /// </summary>
        /// <param name="nom">Le nom éxacte de l'article</param>
        /// <param name="joueur">Le joueur qui vend l'article</param>
        /// <exception cref="ProductNotFoundException">Si aucun article n'as ceci pour nom</exception>
        public void SellArticle(String nom, Joueur joueur)
        {

        }

        /// <summary>
        /// Recherche un article par son nom
        /// </summary>
        /// <param name="nom">Le nom de l'article</param>
        /// <returns>La liste d'article contenant dans leur nom le nom rechercher</returns>
        public List<Article> SearchArticle(String nom)
        {
            throw new NotImplementedException();
        }
    }
}
