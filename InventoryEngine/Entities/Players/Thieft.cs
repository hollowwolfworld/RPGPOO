using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public class Thieft : IPlayer
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
        
        public Thieft(int levels, int xp, int maxHp, int hp, int attack, int defence, int speed, int luck, string name)
        {
            this.maxHp = maxHp;
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

        string IPlayer.Stats()
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
                int xpNeeded = LevelManager.XPNeeded(levels);
                if (xp >= xpNeeded)
                {
                    Random rand = new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray()));
                    xp -= xpNeeded;
                    levels++;
                    maxHp += rand.Next(5, 8);
                    attack += rand.Next(2, 4);
                    defence += rand.Next(1, 3);
                    speed += rand.Next(2, 4);

                    if (rand.Next(0, 100) <= luck)
                    {
                        luck += rand.Next(1, 3);
                    }
                    skills = LevelManager.GetSkillsForLevel(levels, this);
                }
            }
        }
        Inventory IPlayer.PlayerInventory { get => inventory; }
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
        int IEntity.HealthPoint { get => hp; set => hp = value; }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
        int IEntity.MaxHealthPoint { get => maxHp; set => maxHp = value; }
    }
}
