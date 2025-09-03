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
    public class Racket : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if (from is not Thugs) throw new NotAllowedToUseSkill();

            DamageCalculator.CalculateDamage(from.) //to do scale sur l'argent
        }
    }
}
