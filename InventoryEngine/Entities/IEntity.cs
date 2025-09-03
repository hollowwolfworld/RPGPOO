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
        public int HealthPoint { get; set; }
        public int Attack { get; protected set; }
        public int Defence { get; protected set; }
        public int Levels { get; protected set; }
        public string Name { get; }
        public Status Status { get; set; }
        public int Chance { get; protected set; }

        public List<ISkill> Skills { get; set; }
    }
}
