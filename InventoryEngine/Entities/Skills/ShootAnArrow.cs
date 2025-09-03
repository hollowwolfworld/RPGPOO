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
    public class ShootAnArrow : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if(from is not Skeleton) throw new NotAllowedToUseSkill();
            DamageCalculator.CalculateDamage(from, to);
            to.Status[Status.POISONED] = 2;
        }
    }
}
