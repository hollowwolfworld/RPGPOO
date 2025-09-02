using InventoryEngine.Entities.Players;

namespace InventoryEngine.Buildings
{
    public class Bank
    {
        private Dictionary<Player, decimal> Accounts { get; set; }
        public decimal Tax { get; private set; }

        public Bank() 
        {
            Tax = 0.9m;
            Accounts = new Dictionary<Player, decimal>();
        }

        public void Register(Player player)
        {
            Accounts.Add(player, 0);
        }

        public void Deposit(Player player, decimal amount)
        {

        }

        public void Withdraw(Player player, decimal amount)
        {

        }
    }
}
