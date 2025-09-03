namespace EntityEngine.Entities
{
    public static class DamageCalculator
    {
        /// <summary>
        /// Va prendre l'attaque et la chance du lanceur ainsi que la défence de la cible pour calculer les dégats fait à la cible
        /// </summary>
        /// <param name="from">Le lanceur de l'attaque</param>
        /// <param name="to">La cible de l'attaque</param>
        /// <returns>Les dégat en point de vie infligé à la cible</returns>
        public static int CalculateDamage(IEntity from, IEntity to)
        {
            return CalculateDamage(from.Attack, from.Chance, to.Defence);
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

            double result = variance * luckCrit <= luck ? Math.Max(1.1, 10 - luck * 0.089) : 1;

            result = Math.Max(1, Math.Floor(result));

            return Convert.ToInt32(result);
        }
    }
}
