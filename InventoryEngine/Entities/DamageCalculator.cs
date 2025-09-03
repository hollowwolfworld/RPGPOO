using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace EntityEngine.Entities
{
    public static class DamageCalculator
    {
        public static int CalculateDamage(IEntity from, IEntity to)
        {
            return CalculateDamage(from.Attack, from.Chance, to.Defence);
        }

        public static int CalculateDamage(int damage, int chance, int defence)
        {
            int _base = damage - defence / 2;
            var rand = new Random();
            double variance = _base * rand.Next(9, 12) / 10.0;
            int luck = 10 + chance;
            int luckCrit = rand.Next(0, 101);

            double result = variance * luckCrit <= luck ? Math.Max(1.1, 10 - luck * 0.089) : 1;

            result = Math.Max(1, Math.Floor(result));

            return Convert.ToInt32(result);
        }
    }
}
