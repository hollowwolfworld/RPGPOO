using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FightEngine;
using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using System.Linq.Expressions;
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

        public void Hit(IEntity striker, IEntity target)
        {
            if (!VerifyEntity(striker) && !VerifyEntity(target)) throw new Exception();

            var damage = DamageCalculator.CalculateDamage(striker, target);

            target.HealthPoint -= damage;
        }

        public void UseSkill(IEntity striker, IEntity target, ISkill skill)
        {
            if (!VerifyEntity(striker) && !VerifyEntity(target)) throw new Exception();

            if(!striker.Skills.Contains(skill)) throw new Exception();

            skill.UseSkill(striker, target);
        }

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
