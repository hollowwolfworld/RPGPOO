using EntityEngine.Entities.Players;
using EntityEngine.Inventories;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Enemies
{
    public class Thugs : IEnnemy, IHumanoid
    {
        private List<ISkill> skills;
        private Dictionary<Status, int> status;
        private int maxHp;
        private int hp;
        private int attack;
        private int defence;
        private int speed;
        private int levels;
        private string name;
        private int luck;
        private int gold;
        private Inventory inventory;

        public Thugs(string name, int levels, int maxHp, int hp, int attack, int defence, int speed, int luck, int gold, List<ISkill> skills, Dictionary<Status, int> status, Inventory inventory)
        {
            this.name = name;
            this.levels = levels;
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

        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }

        public Inventory Inventory => inventory;

        public int Gold { get => gold; set => gold = value; }
        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
        int IEntity.Attack { get => attack; set => attack = value; }
        int IEntity.Defence { get => defence; set => defence = value; }
        int IEntity.Levels { get => levels; set => levels = value; }
        int IEntity.Luck
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

        public Move ChooseMove()
        {
            throw new NotImplementedException();
        }

        public class Builder
        {
            private string name = "Thugs";
            private int level = 1;
            private int maxHealth = 32;
            private int health = 32;
            private int attack = 9;
            private int defence = 6;
            private int speed = 6;
            private int luck = 5;
            private int gold = 12;
            private Dictionary<Status, int> status = new Dictionary<Status, int>();
            private List<ISkill> skills = LevelManager.GetSkillsForLevel(1, typeof(Thugs));
            private Inventory inventory = new Inventory(5);

            public Thugs Build()
            {
                return new Thugs(name, level, maxHealth, health, attack, defence, speed, luck, gold, skills, status, inventory);
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

            public Builder SetLuck(int luck)
            {
                this.luck = luck;
                return this;
            }

            public Builder SetGold(int gold)
            {
                this.gold = gold; 
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
