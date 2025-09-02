using FightEngine;
using FightEngine.Entities;
using FightEngine.Entities.Enemies;
using FightEngine.Entities.Players;

namespace RPGPOOTest
{
    public class UnitTest1
    {
        public object[] infligeDamageTest1 = {
            new Slime(40, 5, 2, 1, "Slime"),
            new Warrior("warrior"),
            2,
            4
        };

        [Theory]
        [InlineData(infligeDamageTest1)]
        public void TestFight(Entity from, Entity to, int minExpected, int maxExpected)
        {
            LetFight fight = new LetFight();

            fight.InflictDamage(from, to);

            Assert.True(minExpected >= to.HealthPoint && to.HealthPoint >= maxExpected);
        }
    }
}