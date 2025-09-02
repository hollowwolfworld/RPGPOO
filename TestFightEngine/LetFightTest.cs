using FightEngine;
using FightEngine.Entities;
using FightEngine.Entities.Enemies;
using FightEngine.Entities.Players;

namespace TestFightEngine
{
    [TestClass]
    public sealed class LetFightTest
    {
        [DataTestMethod]
        [DataRow(5,50,5,2,4)]
        [DataRow(5,45,5,2,4)]
        public void InflictDamage(int fromEntityAttack, int toEntityHp, int toEntityDefence, int minDamage, int maxDamage)
        {
            Entity from = new Slime(40,fromEntityAttack, 12, 1, "Slime");
            Entity to = new Warrior(toEntityHp, 12, toEntityDefence, "UwU");

            LetFight fight = new LetFight();
            fight.InflictDamage(from, to);

            Assert.IsTrue(toEntityHp - minDamage >= to.HealthPoint && to.HealthPoint >= toEntityHp - maxDamage);
        }
    }
}
