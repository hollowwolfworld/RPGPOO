using EntityEngine.Entities;
using EntityEngine.Entities.Players;
using FightEngine.Skills;
using EntityEngine.Inventories.Items;

namespace FightEngine
{
    public class Arena
    {
        public IEntity FirstFighter { get; private set; }
        public IEntity SecondFighter { get; private set; }

        public Arena(IEntity firstFighter, IEntity secondFighter)
        {
            FirstFighter = firstFighter;
            SecondFighter = secondFighter;
        }

        /// <summary>
        /// Effectue une attack simple
        /// </summary>
        /// <param name="striker">L'attaquant</param>
        /// <param name="target">Le défenceur</param>
        /// <exception cref="Exception">Lance une exeption si les entité ne sont pas dans l'arène</exception>
        public void Hit(IEntity striker, IEntity target)
        {
            if (!VerifyEntity(striker) && !VerifyEntity(target)) throw new Exception();

            var damage = DamageCalculator.CalculateDamage(striker, target);

            target.HealthPoint -= damage;
        }

        /// <summary>
        /// Fait utiliser un skill par le lanceur sur le défenceur
        /// </summary>
        /// <param name="striker">Le lanceur</param>
        /// <param name="target">Le défenceur</param>
        /// <param name="skill">Le skill à utiliser</param>
        /// <exception cref="Exception">Lance une exeption si le lanceur n'as pas le skill ou si le lanceur et la cible ne sont pas dans l'arène</exception>
        public void UseSkill(IEntity striker, IEntity target, ISkill skill)
        {
            if (!VerifyEntity(striker) && !VerifyEntity(target)) throw new Exception();

            if(!striker.Skills.Contains(skill)) throw new Exception();

            skill.UseSkill(striker, target);
        }

        /// <summary>
        /// Le lanceur utilise un item sur la cible
        /// </summary>
        /// <param name="striker">Le lanceur</param>
        /// <param name="targer">La cible</param>
        /// <param name="item">L'item</param>
        /// <exception cref="Exception">Lance une exeption si le lanceur n'as pas l'item dans son inventaire et ou si l'item n'est pas utilisable ou si le lanceur n'est pas un joueur ou si le lanceur et la cible ne sont pas dans l'arène</exception>
        public void UseItems(IEntity striker, IEntity targer, Item item)
        {
            if (!VerifyEntity(striker) && !VerifyEntity(targer)) throw new Exception();
            if (striker is not IPlayer player) throw new Exception();
            if (player.Inventory[item] == -1) throw new Exception();
            if (item is not UsableItem usableItem) throw new Exception();

            usableItem.Use(targer);
        }

        /// <summary>
        /// Verifie si l'entité est dans l'arène
        /// </summary>
        /// <param name="entity">L'entité</param>
        /// <returns>Vrai si l'entité est dans l'arène sinon faux</returns>
        private bool VerifyEntity(IEntity entity) => entity == FirstFighter || entity == SecondFighter;
    }
}
