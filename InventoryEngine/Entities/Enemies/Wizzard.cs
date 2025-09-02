using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Enemies
{
    public class Wizzard : IEnnemy, IMagical
    {
        protected Wizzard(int hp, int attack, int defence, int manaPoint, int levels, string name)
        {
        }
        int IEntity.HealthPoint { get; set; }
        int IEntity.Attack { get; set; }
        int IEntity.Defence { get; set; }
        int IEntity.Levels { get; set; }
        string IEntity.Name { get; set; }
        Status IEntity.Status { get; set; }
        int IEntity.Chance { get; set; }
        List<Skill> IEntity.Skills { get; set; }
        int IMagical.ManaPoint { get; set; }
    }
}
