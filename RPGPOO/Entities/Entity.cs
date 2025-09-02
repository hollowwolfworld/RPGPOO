using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGPOO.Entities
{
    public abstract class Entity
    {
        public int HealthPoint { get; protected set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
        public int Levels { get; protected set; }
        public string Name { get; protected set; }

        public Skills skills { get; set; }

       protected Entity(int healthPoint,int attack,int defence, int levels,string name)
        {
            HealthPoint = healthPoint;
            Attack = attack;
            Defence = defence;
            Levels = levels;
            Name = name;
        }

        public Entity(string name)
        {
            Name = name;
        }
    }
}
