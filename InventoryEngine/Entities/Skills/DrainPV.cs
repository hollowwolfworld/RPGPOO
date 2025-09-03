using EntityEngine.Entities.Enemies;
using EntityEngine.Exceptions;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Skills
{
    public class DrainPV: ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if (from is not IMagical magical) throw new NotAllowedToUseSkill();
            if (from is not Slime slime) throw new NotAllowedToUseSkill();
            
            int drain = 5 + from.Levels / 2;

            from.HealthPoint += drain;
            to.HealthPoint -= drain;
            magical.ManaPoint -= 2;
        }
    }
}
