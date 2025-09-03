using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Thieft : IPlayer
    {
        private List<ISkill> skills;
        private Inventory inventory;
        private Status status;
        private int levels;
        private int xp;
        private int hp;
        private int attack;
        private int defence;
        private int speed;
        private string name;
        private int luck;
        
        public Thieft(int levels, int xp, int hp, int attack, int defence, int speed, int luck, string name)
        {
            this.hp = hp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.levels = levels;
            this.xp = xp;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
            this.inventory = new Inventory(5);
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
        Status IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }

    }
}
