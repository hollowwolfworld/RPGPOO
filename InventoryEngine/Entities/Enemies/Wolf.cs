using EntityEngine.Entities.Players;
using FightEngine.Skills;

namespace EntityEngine.Entities.Enemies
{
    public class Wolf : IEnnemy
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

        public Wolf(string name, int maxHp, int hp, int attack, int defence, int speed, int levels, int luck, List<ISkill> skills, Dictionary<Status, int> status)
        {
            this.name = name;
            this.maxHp = maxHp;
            this.hp = hp;
            this.attack = attack;
            this.defence = defence;
            this.speed = speed;
            this.levels = levels;
            this.luck = luck;
            this.skills = skills;
            this.status = status;
        }

        public int MaxHealthPoint { get => maxHp; set => maxHp = value; }
        List<ISkill> IEntity.Skills { get => skills; set => skills = value; }
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

        public Move ChooseMove()
        {
            throw new NotImplementedException();
        }

        public class Builder
        {
            private string name = "Wolf";
            private int level = 1;
            private int maxHealth = 30;
            private int health = 30;
            private int attack = 8;
            private int defence = 5;
            private int speed = 7;
            private int luck = 4;
            private Dictionary<Status, int> status = new Dictionary<Status, int>();
            private List<ISkill> skills = LevelManager.GetSkillsForLevel(1, typeof(Wolf));

            public Wolf Build()
            {
                return new Wolf(name, level, maxHealth, health, attack, defence, speed, luck, skills, status);
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
