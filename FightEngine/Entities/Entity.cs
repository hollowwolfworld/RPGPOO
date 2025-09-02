using InventoryEngine.Skills;

namespace InventoryEngine.Entities
{
    public abstract class Entity
    {
        public int HealthPoint { get; protected set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
        public int Levels { get; protected set; }
        public string Name { get; protected set; }

        public List<Skill> Skills { get; set; }

       protected Entity(int healthPoint,int attack,int defence, int levels,string name)
        {
            HealthPoint = healthPoint;
            Attack = attack;
            Defence = defence;
            Levels = levels;
            Name = name;
            Skills = new List<Skill>();
        }

        public Entity(string name)
        {
            Name = name;
            Skills = new List<Skill>();
        }
    }
}
