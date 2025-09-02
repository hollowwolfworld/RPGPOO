using FightEngine.Skills;

namespace FightEngine.Entities
{
    public abstract class Entity
    {
        public int HealthPoint { get; internal set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
        public int Levels { get; protected set; }
        public string Name { get; protected set; }

        public int Chance { get; protected set; }
        public List<Skill> Skills { get; set; }

       protected Entity(int healthPoint,int attack,int defence, int levels,string name)
        {
            HealthPoint = healthPoint;
            Attack = attack;
            Defence = defence;
            Levels = levels;
            Name = name;
            Skills = new List<Skill>();
            Chance = new Random().Next(1,101);
        }

        public Entity(string name)
        {
            Name = name;
            Skills = new List<Skill>();
        }

    }
}
