using EntityEngine.Inventories;
using FightEngine.Skills;

namespace EntityEngine.Entities.Players
{
    public class Warrior : IPlayer
    {
        private List<ISkill> skills;
        private Inventory inventory;
        private Dictionary<Status, int> status;
        private int levels;
        private int xp;
        private int maxHp;
        private int hp;
        private int attack;
        private int defence;
        private int speed;
        private string name;
        private int luck;

        public Warrior(int levels, int xp, int maxHp, int hp, int attack, int defence, int speed, int luck, string name)
        {
            this.levels = levels;
            this.xp = xp;
            this.hp = hp;
            this.maxHp = maxHp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
            this.inventory = new Inventory(5);
            status = new Dictionary<Status, int>();
        }

        public string Stats()
        {
            throw new NotImplementedException();
        }

        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
        int IPlayer.XP
        {
            get => xp;
            set
            {
                xp = value;
                int xpNeeded = Convert.ToInt32(Math.Round(50 + 25 * Math.Pow(levels, 1.5)));
                if (xp >= xpNeeded)
                {
                    xp -= xpNeeded;
                    levels++;
                }
            }
        }
        Inventory IPlayer.PlayerInventory { get => inventory; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Chance { get => luck; set => luck = value; }
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }
    }
}
