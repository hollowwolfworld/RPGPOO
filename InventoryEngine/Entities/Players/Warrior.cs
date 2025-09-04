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
        private int gold;

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
            this.gold = gold;
            this.skills = new List<ISkill>();
            this.inventory = new Inventory(5);
            status = new Dictionary<Status, int>();
        }

        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
        int IPlayer.XP
        {
            get => xp;
            set
            {
                xp = value;
                int xpNeeded = LevelManager.XPNeeded(levels);
                if (xp >= xpNeeded)
                {
                    var rand = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
                    xp -= xpNeeded;
                    levels++;
                    maxHp += rand.Next(8, 13);
                    attack += rand.Next(3, 5);
                    defence += rand.Next(2, 4);
                    speed += 1;

                    if (rand.Next(0, 100) <= luck)
                    {
                        luck += rand.Next(0, 2);
                    }
                    skills = LevelManager.GetSkillsForLevel(levels, this);
                }
            }
        }
        Inventory IHumanoid.Inventory { get => inventory; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Chance { get => luck; 
            set 
            {
                if (value < 0) return;
                if (value > 100)
                {
                    luck = 100;
                    return;
                }
                luck = value;
            } 
        }
        int IEntity.HealthPoint { get => hp; 
            set
            {
                if (value <= maxHp) hp = value;
                else hp = maxHp;
            }
        }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }
        public int Gold { get => gold; set => gold; }
    }
}
