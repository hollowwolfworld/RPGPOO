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
        [DataRow(5, 6, 1, 1, -1)]

        [DataRow(5, 6, 1000, 1000, 0)]

        [DataRow(5, 6, 1000, 1, 1)]

        [DataRow(5, 4 , 1, 1, 1)]

        [DataRow(5, 4, 1, 1000, -1)]

        [DataRow(5, 5 ,1, 1, 1)]
        
        public void Testspeed(int fromSpeed, int toSpeed,int fromHp, int  toHp, int expected)
        {
            IEntity to = new Slime.Builder()
               .SetSpeed(toSpeed)
               .SetHealth(toHp)
               .Build();

            IEntity from = new Warrior.Builder()
                .SetSpeed(fromSpeed)
                .SetHealth(fromHp)
                .Build();

            FightTurns test = new FightTurns(from, to);
            Move move = new SimpleMove();
            MoveAction deux = new MoveAction(from, move);
            MoveAction un = new MoveAction(to, move);

            int result = test.Turn(un, deux);

            Assert.AreEqual(expected, result);

        }
        [DataTestMethod]
        [DataRow(Status.PARALYSED, null, 5, 6, 1000, 1, 0)]
        [DataRow(null, Status.PARALYSED, 5, 6, 1000, 1, 1)]
        [DataRow(Status.PARALYSED, null, 5, 6, 1, 1000, -1)]
        [DataRow(null, Status.PARALYSED, 5, 6, 1, 1000, 0)]

        [DataRow(Status.PARALYSED, null, 5, 4, 1000, 1, 0)]
        [DataRow(null, Status.PARALYSED, 5, 4, 1000, 1, 1)]
        [DataRow(Status.PARALYSED, null, 5, 4, 1, 1000, -1)]
        [DataRow(null, Status.PARALYSED, 5, 4, 1, 1000, 0)]

        [DataRow(Status.PARALYSED, null, 5, 5, 1000, 1,  0)]
        [DataRow(null, Status.PARALYSED, 5, 5, 1000, 1, 1)]
        [DataRow(Status.PARALYSED, null, 5, 5, 1, 1000, -1)]
        [DataRow(null, Status.PARALYSED, 5, 5, 1, 1000, 0)]
        [DataRow(Status.PARALYSED, Status.PARALYSED, 5, 5, 1, 1000, 0)]

        public void TestStatuePara(Status statusFrom,Status statusTo, int fromSpeed, int toSpeed, int fromHp, int toHp, int expected)
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

            IEntity from = new Warrior.Builder()
               .SetSpeed(fromSpeed)
               .SetHealth(fromHp)
               .SetMaxHealth(fromHp)
               .SetStatus(dicFrom)
               .Build();

            IEntity to = new Slime.Builder()
                .SetSpeed(toSpeed)
                .SetHealth(toHp)
                .SetMaxHealth(toHp)
                .SetStatus(dicTo)
                .Build();


            FightTurns test = new FightTurns(from, to);
            Move move = new SimpleMove();
            MoveAction un = new MoveAction(to, move);
            MoveAction deux = new MoveAction(from, move);

            int result = test.Turn(un, deux);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(Status.BURN, null, 1000, 1, 950)]
        [DataRow(null, Status.BURN, 1000, 1, 1)]
        [DataRow(Status.BURN, Status.BURN, 1, 1000,950)]
        public void TestStatueBurn(Status statusFrom, Status statusTo, int fromHp, int toHp, int expected)
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

            IEntity from = new Warrior.Builder()
              
              .SetHealth(fromHp)
              .SetMaxHealth(fromHp)
              .SetStatus(dicFrom)
              .Build();

            IEntity to = new Slime.Builder()
                
                .SetHealth(toHp)
                .SetMaxHealth(toHp)
                .SetStatus(dicTo)
                .Build();

            FightTurns test = new FightTurns(from, to);
            Move move = new DoNothing();
            MoveAction un = new MoveAction(to, move);
            MoveAction deux = new MoveAction(from, move);

            test.Turn(un, deux);

            Assert.IsTrue(expected == from.HealthPoint || expected == to.HealthPoint);
        }
    }
}
