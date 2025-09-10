using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class Bite : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            double damage = DamageCalculator.CalculateDamage(from, to);

            if (from is not Wolf) throw new NotAllowedToUseSkill();

            if (to is Warrior)
            {
                damage *= 0.5;

                damage = Math.Max(1, Math.Floor(damage));

                int d = Convert.ToInt32(damage);

                to.HealthPoint -= d;

            } else if (to is Sorcerer)
            {
                damage *= 1.5;

                damage = Math.Max(1, Math.Floor(damage));

                int d = Convert.ToInt32(damage);

                to.HealthPoint -= d;
            }

            to.HealthPoint -= Convert.ToInt32(damage);
        }
    }
}
