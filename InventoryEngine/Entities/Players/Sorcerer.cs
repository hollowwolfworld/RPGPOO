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
        private Dictionary<Status, int> status;
        private int maxHp;
        private int hp;
        private int maxMp;
        private int mp;
        private int attack;
        private int defence;
        private int speed;
        private string name;
        private int luck;
        private int gold;

        public Sorcerer(int levels, int xp, List<ISkill> skills, Inventory inventory, Dictionary<Status, int> status, int maxHp, int hp, int maxMp, int mp, int attack, int defence, int speed, string name, int luck, int gold)
        {
            this.levels = levels;
            this.xp = xp;
            this.skills = skills;
            this.inventory = inventory;
            this.status = status;
            this.maxHp = maxHp;
            this.hp = hp;
            this.maxMp = maxMp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.name = name;
            this.luck = luck;
            this.gold = gold;
        }

        public Sorcerer(int levels, int xp, int maxMp, int maxHp, int hp, int attack, int defence, int speed, int luck, int mp, string name)
        {
            this.levels = levels;
            this.xp = xp;
            this.maxHp = maxHp;
            this.hp = hp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.name = name;
            this.luck = luck;
            this.name = name;
            this.skills = new List<ISkill>();
            this.inventory = new Inventory(5);
            this.status = new Dictionary<Status, int>();
        }

        public Sorcerer(string name)
        {
            this.name = name;
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
                    Random rand = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
                    xp -= xpNeeded;
                    levels++;
                    maxHp += rand.Next(4, 7);
                    attack += rand.Next(0, 2);
                    defence += rand.Next(0, 2);
                    maxMp += rand.Next(3, 5);
                    speed += rand.Next(1,3);

                    if(rand.Next(0, 100) <= luck)
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
        int IEntity.Chance
        {
            get => luck;
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
        int IMagical.ManaPoint { get => mp;
            set
            {
                if (value <= maxMp) hp = value;
                else hp = maxMp;
            }
        }
        int IEntity.Speed { get => speed; set => speed = value; }
        int IEntity.MaxHealthPoint { get => maxHp; set => maxHp = value; }
        int IMagical.MaxManaPoint { get => maxMp; set => maxMp = value; }
        public int Gold { get => gold; set => gold = value; }
    }
}
