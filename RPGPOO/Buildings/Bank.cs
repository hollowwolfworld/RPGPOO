using EntityEngine.Entities.Players;

namespace RPGPOO.Buildings
{
    public class Bank
    {
        private Dictionary<IPlayer, decimal> Accounts { get; set; }
        public decimal Tax { get; private set; }

        public Bank() 
        {
            Tax = 0.9m;
            Accounts = new Dictionary<IPlayer, decimal>();
        }

        public void Register(IPlayer player)
        {
            Accounts.Add(player, 0);
        }

        public void Deposit(IPlayer player, decimal amount)
        {

        }

        public void Withdraw(IPlayer player, decimal amount)
        {

        }
    }
}
