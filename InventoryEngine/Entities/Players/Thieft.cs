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
        private int gold;

        public Thieft(string name, int levels, int xp, int maxHp, int hp, int attack, int defence, int speed, int luck, int gold, Dictionary<Status, int> status, 
            List<ISkill> skills, Inventory inventory)
        {
            this.name = name;
            this.levels = levels;
            this.xp = xp;
            this.maxHp = maxHp;
            this.hp = hp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.luck = luck;
            this.gold = gold;
            this.status = status;
            this.skills = skills;
            this.inventory = inventory;
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
                    skills = LevelManager.GetSkillsForLevel(levels, GetType());
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
        int IEntity.Speed { get => speed; set => speed = value; }
        int IEntity.MaxHealthPoint { get => maxHp; set => maxHp = value; }
        public int Gold { get => gold; set => gold = value; }

        public class Builder
        {
            private string name = "Thieft";
            private int level = 1;
            private int experience = 0;
            private int maxHealth = 50;
            private int health = 50;
            private int attack = 12;
            private int defence = 10;
            private int speed = 6;
            private int luck = new Random().Next(0, 100);
            private int gold = 0;
            private Dictionary<Status, int> status = new Dictionary<Status, int>();
            private List<ISkill> skills = LevelManager.GetSkillsForLevel(1, typeof(Thieft));
            private Inventory inventory = new Inventory(5);

            public Thieft Build()
            {
                return new Thieft(name, level, experience, maxHealth, health, attack, defence, speed, luck, gold, status, skills, inventory);
            }

            public Builder SetName(string name)
            {
                this.name = name;
                return this;
            }

            public Builder SetLevel(int level)
            {
                this.level = level;
                return this;
            }

            public Builder SetExperience(int experience)
            {
                this.experience = experience;
                return this;
            }

            public Builder SetMaxHealth(int maxHealth)
            {
                this.maxHealth = maxHealth;
                return this;
            }

            public Builder SetHealth(int health)
            {
                this.health = health;
                return this;
            }

            public Builder SetAttack(int attack)
            {
                this.attack = attack;
                return this;
            }

            public Builder SetDefence(int defence)
            {
                this.defence = defence;
                return this;
            }

            public Builder SetSpeed(int speed)
            {
                this.speed = speed;
                return this;
            }

            public Builder SetGold(int gold)
            {
                this.gold = gold;
                return this;
            }

            public Builder SetLuck(int luck)
            {
                this.luck = luck;
                return this;
            }

            public Builder SetStatus(Dictionary<Status, int> status)
            {
                this.status = status;
                return this;
            }

            public Builder SetSkills(List<ISkill> skills)
            {
                this.skills = skills;
                return this;
            }

            public Builder SetInventory(Inventory inventory)
            {
                this.inventory = inventory;
                return this;
            }
        }
    }
}
