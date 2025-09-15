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
    public class Slime : IEnnemy, IMagical
    {
        private List<ISkill> skills;
        private Dictionary<Status, int> status;
        private int maxHp;
        private int hp;
        private int maxMp;
        private int mp;
        private int attack;
        private int defence;
        private int speed;
        private int levels;
        private string name;
        private int luck;

        public Slime(string name, int levels, int maxHp, int hp, int maxMp, int mp, int attack, int defence, int speed, int luck, List<ISkill> skills, Dictionary<Status, int> status)
        {
            this.name = name;
            this.levels = levels;
            this.maxHp = maxHp;
            this.hp = hp;
            this.maxMp = maxMp;
            this.mp = mp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.luck = luck;
            this.skills = skills;
            this.status = status;
        }

        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }
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
        int IMagical.ManaPoint
        {
            get => mp;
            set
            {
                if (value <= maxMp) hp = value;
                else hp = maxMp;
            }
        }
        string IEntity.Name { get => name; }
        Dictionary<Status, int> IEntity.Status { get => status; set => status = value; }
        int IEntity.Speed { get => speed; set => speed = value; }
        int IMagical.MaxManaPoint { get => maxMp; set => maxMp = value; }

        public Move ChooseMove()
        {
            throw new NotImplementedException();
        }

        public class Builder
        {
            private string name = "Slime";
            private int level = 1;
            private int maxHealth = 22;
            private int health = 22;
            private int maxMp = 5;
            private int mp = 5;
            private int attack = 4;
            private int defence = 3;
            private int speed = 5;
            private int luck = 3;
            private Dictionary<Status, int> status = new Dictionary<Status, int>();
            private List<ISkill> skills = LevelManager.GetSkillsForLevel(1, typeof(Slime));

            public Slime Build()
            {
                return new Slime(name, level, maxHealth, health, maxMp, mp, attack, defence, speed, luck, skills, status);
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
        }
    }
}
