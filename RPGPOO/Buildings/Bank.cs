using EntityEngine.Entities.Players;
using RPGPOO.Exceptions;

namespace RPGPOO.Buildings
{
    public class Bank
    {
        private Dictionary<IPlayer, decimal> Accounts { get; set; }
        public decimal Tax { get; private set; }

        public Bank() 
        {
            Tax = 0.9m;
            Accounts = [];
        }

        /// <summary>
        /// Enregistre le compte d'un joueur
        /// </summary>
        /// <param name="player">Le joueur qui posséderas le compte</param>
        public void Register(IPlayer player)
        {
            Accounts.Add(player, 0);
        }

        /// <summary>
        /// Dépose de l'argent à la banque avec une taxe de 10%
        /// </summary>
        /// <param name="player">Le propriétaire du compte</param>
        /// <param name="amount">La quantité d'argent à déposer</param>
        /// <exception cref="NotEnoughtGoldException">Si le propriétaire ne peut pas déposer cette quantité de gold</exception>
        /// <exception cref="PlayerNotFoundException">Si le propriétaire n'as pas de compte</exception>
        public void Deposit(IPlayer player, decimal amount)
        {
            if (player.Gold < amount * Tax) throw new NotEnoughtGoldException($"Vou n'avez pas assez pour déposer et payé la tax\n{amount * Tax}");
            if (!Accounts.ContainsKey(player)) throw new PlayerNotFoundException(player.Name);

            Accounts[player] += amount;
            player.Gold -= amount * Tax;
        }

        /// <summary>
        /// Retire de l'argent à la banque avec une taxe de 10%
        /// </summary>
        /// <param name="player">Le propriétaire du compte</param>
        /// <param name="amount">La quantité à retirer</param>
        /// <exception cref="PlayerNotFoundException">Si le propriétaire n'as pas de compte</exception>
        /// <exception cref="NotEnoughtGoldException">Si le compte ne peut pas retirer cette quantité de gold</exception>
        public void Withdraw(IPlayer player, decimal amount)
        {
            if (!Accounts.ContainsKey(player)) throw new PlayerNotFoundException(player.Name);
            if (Accounts[player] < amount * Tax) throw new NotEnoughtGoldException($"Il n'y a pas assez pour retirer et payé la tax\n{amount * Tax}");

            Accounts[player] -= amount * Tax;
            player.Gold += amount;
        }
    }
}
