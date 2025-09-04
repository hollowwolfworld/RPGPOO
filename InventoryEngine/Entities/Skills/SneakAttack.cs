using EntityEngine.Entities;
using EntityEngine.Entities.Players;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class SneakAttack : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if (from is not Thieft) throw new NotAllowedToUseSkill();

            int result = DamageCalculator.CalculateDamage(from.Attack, from.Chance, 0);

            to.HealthPoint -= result;
        }
    }
}
