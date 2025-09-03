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
            int hp = 40;
            int mp = 10;
            int attack = 12;
            int defence = 12;
            int luck = 50;
            int level = 1;
            int xp = 0;

            IEntity from = new Slime(hp, mp, fromEntityAttack, defence, luck, level, "Slime");
            IEntity to = new Warrior(xp, level, toEntityHp, attack, toEntityDefence, luck, "UwU");

            LetFight fight = new LetFight();
            fight.InflictDamage(from, to);

            Assert.IsTrue(toEntityHp - minDamage >= to.HealthPoint && to.HealthPoint >= toEntityHp - maxDamage);

        }
    }
}
