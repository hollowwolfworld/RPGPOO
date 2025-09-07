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

            Assert.IsTrue(to.HealthPoint <= toHp - minDamage && to.HealthPoint >= toHp - maxDamage);
        }

        [DataTestMethod]
        [DataRow(5, 6, 1000, 1, 1)]
        [DataRow(5, 6, 1, 1000, -1)]
        [DataRow(5, 4 , 1000, 1, 1)]
        [DataRow(5, 4, 1, 1000, -1)]
        [DataRow(5, 5 ,1000, 1, 1)]
        [DataRow(5, 5, 1, 1000, -1)]
        public void Testspeed(int fromSpeed, int toSpeed,int fromHp, int  toHp, int expected)
        {
            IEntity from = new Slime.Builder()
               .SetSpeed(fromSpeed)
               .SetHealth(fromHp)
               .Build();

            IEntity to = new Warrior.Builder()
                .SetSpeed(toSpeed)
                .SetHealth(toHp)
                .Build();

            FightTurns test = new FightTurns(from, to);
            Move move = new SimpleMove();
            MoveAction un = new MoveAction(to, move);
            MoveAction deux = new MoveAction(from, move);

            int result = test.Turn(un, deux);

            Assert.AreEqual(expected, result);

        }
        [DataTestMethod]
        [DataRow(Status.PARALYSED, null, 5, 6, 1000, 1, 1)]
        [DataRow(null, Status.PARALYSED, 5, 6, 1000, 1, 1)]
        [DataRow(Status.PARALYSED, null, 5, 6, 1, 1000, -1)]
        [DataRow(null, Status.PARALYSED, 5, 6, 1, 1000, 1)]

        [DataRow(Status.PARALYSED, null, 5, 4, 1000, 1, 1)]
        [DataRow(null, Status.PARALYSED, 5, 4, 1000, 1, -1)]
        [DataRow(Status.PARALYSED, null, 5, 4, 1, 1000, 1)]
        [DataRow(null, Status.PARALYSED, 5, 4, 1, 1000, 1)]

        [DataRow(Status.PARALYSED, null, 5, 5, 1000, 1, 1)]
        [DataRow(null, Status.PARALYSED, 5, 5, 1000, 1, -1)]
        [DataRow(Status.PARALYSED, null, 5, 5, 1, 1000, 1)]
        [DataRow(null, Status.PARALYSED, 5, 5, 1, 1000, 1)]
        [DataRow(Status.PARALYSED, Status.PARALYSED, 5, 5, 1, 1000, 0)]

        public void TestStatue(Status statusFrom,Status statusTo, int fromSpeed, int toSpeed, int fromHp, int toHp, int expected)
        {
            var dicFrom = new Dictionary<Status, int>()
            {
                {
                    statusFrom,
                    2
                },
            };
            var dicTo = new Dictionary<Status, int>()
            {
                {
                    statusTo,
                    2
                },
            };

            IEntity from = new Slime.Builder()
               .SetSpeed(fromSpeed)
               .SetHealth(fromHp)
               .SetStatus(dicFrom)
               .Build();

            IEntity to = new Warrior.Builder()
                .SetSpeed(toSpeed)
                .SetHealth(toHp)
                .SetStatus(dicTo)
                .Build();


            FightTurns test = new FightTurns(from, to);
            Move move = new SimpleMove();
            MoveAction un = new MoveAction(to, move);
            MoveAction deux = new MoveAction(from, move);

            int result = test.Turn(un, deux);

            Assert.AreEqual(expected, result);
        }
    }
}
