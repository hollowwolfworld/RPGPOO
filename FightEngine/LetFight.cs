using FightEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine
{
    public class LetFight
    {
        public void InflictDamage(Entity from, Entity to)
        {
            to.inflictDamage(2);
        }
    }
}
