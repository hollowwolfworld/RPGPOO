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
        [DataRow(5, 50, 0, 12, 1, 1)]
        [DataRow(7, 45, 100, 6, 3, 4)]
        [DataRow(7, 45, 0, 6, 3, 44)]
        public void InflictDamage(int fromEntityAttack, int toEntityHp, int fromEntityLuck, int toEntityDefence,
            int minDamage, int maxDamage)
        {
            int maxHp = 40;
            int hp = 40;
            int maxMp = 10;
            int mp = 10;
            int attack = 12;
            int defence = 12;
            int speed = 5;
            int luck = 50;
            int level = 1;
            int xp = 0;

            IEntity from = new Slime(maxHp, hp, maxMp, mp, fromEntityAttack, defence, speed, fromEntityLuck, level, "Slime");
            IEntity to = new Warrior(xp, level, toEntityHp, toEntityHp, attack, toEntityDefence, speed, luck, "UwU");

            int damage = DamageCalculator.CalculateDamage(from, to);

            Assert.IsTrue(damage >= minDamage && damage <= maxDamage);
        }
    }
}
