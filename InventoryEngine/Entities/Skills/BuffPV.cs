using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class BuffPV : ISkill
    {
        
        public void UseSkill(IEntity from, IEntity to)
        {
            if (from is not IMagical) throw new NotAllowedToUseSkill();

            from.HealthPoint += 10 + from.Levels / 2;
        }
    }
}
