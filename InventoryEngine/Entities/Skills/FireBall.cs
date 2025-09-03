using EntityEngine.Entities;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class FireBall : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if(from is not IMagical mage) throw new NotAllowedToUseSkill();

            int damage = DamageCalculator.CalculateDamage(7, from.Chance, to.Defence);
            to.HealthPoint -= damage;
            to.Status[Status.BURN] = 2;
            mage.ManaPoint -= 3;//a equilibrer 
        }
    }
}
