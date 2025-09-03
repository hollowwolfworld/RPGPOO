using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Sorcerer : IPlayer, IMagical
    {
        private int levels;
        private int xp;
        private List<ISkill> skills;
        private Inventory inventory;
        private Status status;
        private int hp;
        private int attack;
        private int defence;
        private int speed;
        private int mp;
        private string name;
        private int luck;

        public Sorcerer(int levels, int xp, int hp, int attack, int defence, int speed, int luck, int mp, string name)
        {
            this.levels = levels;
            this.xp = xp;
            this.hp = hp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
            this.inventory = new Inventory(5);
            this.status = Status.CLEAR;
        }

        public Sorcerer(int levels, int xp, string name) : this(levels, xp, 10, 1, 1, 1, new Random().Next(0, 101), 10, name)
        {

        }

        public Sorcerer(int levels, int xp, int luck, string name) : this(levels, xp, 10, 1, 1, 1, luck, 10, name)
        {

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
                int xpNeeded = Convert.ToInt32(Math.Round(75 * Math.Pow(levels, 1.5)));
                if (xp >= xpNeeded)
                {
                    Random rand = new Random();
                    xp -= xpNeeded;
                    levels++;
                    hp += rand.Next(8, 13);
                    attack += rand.Next(3, 5);
                    defence += rand.Next(2, 4);
                    speed += 1;
                    if(rand.Next(0, 100) <= luck)
                    {
                        luck += rand.Next(0, 2);
                    }
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
        int IMagical.ManaPoint { get => mp; set => mp = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
    }
}
