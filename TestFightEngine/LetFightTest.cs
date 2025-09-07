using FightEngine;
using EntityEngine.Entities;
using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using System.Security.Cryptography;
using EntityEngine;

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
            IEntity from = new Slime.Builder()
                .SetAttack(fromEntityAttack)
                .SetLuck(fromEntityLuck)
                .Build();

            IEntity to = new Warrior.Builder()
                .SetHealth(toEntityHp)
                .SetDefence(toEntityDefence)
                .Build();

            Arena test = new Arena(from, to);

            int toHp = to.HealthPoint;

            test.Hit(from,to);

            Assert.IsTrue(to.HealthPoint >= toHp - minDamage && to.HealthPoint <= toHp - maxDamage);
        }

        [DataTestMethod]
        [DataRow(5, 6)]
        [DataRow(5, 4)]
        [DataRow(5, 5)]
        

        public void Testspeed(int fromSpeed, int toSpeed)
        {
            IEntity from = new Slime.Builder()
               .SetSpeed(fromSpeed)
               .Build();

            IEntity to = new Warrior.Builder()
                .SetSpeed(toSpeed)
                .Build();

            FightTurns test = new FightTurns(from, to);
            SimpleMove moveUn = new SimpleMove();
            MoveAction un = new MoveAction(to,moveUn);
            SimpleMove moveDeux = new SimpleMove();
            MoveAction deux = new MoveAction(from, moveDeux);

            test.Turn(un, deux);

            Assert.EndsWith()
        }
    }
}
