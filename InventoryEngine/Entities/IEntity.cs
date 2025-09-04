using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities
{
    public interface IEntity
    {
        public string Name { get; }
        public int Levels { get; protected set; }
        public int MaxHealthPoint { get; set; }     
        public int HealthPoint { get; set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
        public int Speed { get; protected set; }
        public int Luck { get; protected set; }
        public Dictionary<Status, int> Status { get; protected set; }
        public List<ISkill> Skills { get; set; }
    }
}
