using FightEngine;
using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;

namespace TestFightEngine
{
    [TestClass]
    public sealed class LetFightTest
    {
        [DataTestMethod]
        [DataRow(5,50,12,1,1)]
        [DataRow(7,45,6,3,6)]
        public void InflictDamage(int fromEntityAttack, int toEntityHp, int toEntityDefence, 
            int minDamage, int maxDamage)
        {
            Entity from = new Slime(40,fromEntityAttack, 12, 1, "Slime");
            Entity to = new Warrior(toEntityHp, 12, toEntityDefence, "UwU");

            LetFight fight = new LetFight();
            fight.InflictDamage(from, to);

            Assert.IsTrue(toEntityHp - minDamage >= to.HealthPoint && to.HealthPoint >= toEntityHp - maxDamage);

        }
    }
}
