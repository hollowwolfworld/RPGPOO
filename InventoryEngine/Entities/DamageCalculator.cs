using FightEngine.Skills;

namespace EntityEngine.Entities
{
    public static class DamageCalculator
    {
        private static int MaxDamageBoost = 1000; // c'est en poucent (ex: 1000 => 1000% => 10)

        /// <summary>
        /// Va prendre l'attaque et la chance du lanceur ainsi que la défence de la cible pour calculer les dégats fait à la cible
        /// </summary>
        /// <param name="from">Le lanceur de l'attaque</param>
        /// <param name="to">La cible de l'attaque</param>
        /// <returns>Les dégat en point de vie infligé à la cible</returns>
        public static int CalculateDamage(IEntity from, IEntity to)
        {
            var rageBoost = 1.0;
            if(from.Status.ContainsKey(Status.RAGE))
            {
                rageBoost = 1.5;
            }
            return CalculateDamage(Convert.ToInt32(Math.Round(from.Attack * rageBoost)), from.Luck, to.Defence);
        }

        /// <summary>
        /// Donne le nombre de points de vie qui seras enlever par l'attaque
        /// </summary>
        /// <param name="damage">Les dégats de base</param>
        /// <param name="chance">La chance du lanceur</param>
        /// <param name="defence">La défence de la cible</param>
        /// <returns>Les dégats en point de vie infligé à la cible</returns>
        public static int CalculateDamage(int damage, int chance, int defence)
        {
            int _base = damage - defence / 2;
            var rand = new Random();
            double variance = _base * rand.Next(9, 12) / 10.0;
            int luck = 10 + chance;
            int luckCrit = rand.Next(0, 101);

            double result = variance * (luckCrit <= luck ? GetDamageCritMultiplier(Math.Min(100, chance)) : 1);

            result = Math.Max(1, Math.Floor(result));

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="luck"></param>
        /// <returns></returns>
        private static double GetDamageCritMultiplier(int luck)
        {
            var result = ((luck * MaxDamageBoost - 100.0 * MaxDamageBoost - 110.0 * luck + 2000.0) / -90.0) + 10.0;
            return Math.Min(MaxDamageBoost, result) / 100;
        }
    }
}
