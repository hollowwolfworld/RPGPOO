using FightEngine.Entities;
using FightEngine.Entities.Enemies;
using System.Security.Cryptography;

namespace TestRGP
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod(
            int fromDamage,
            int toHp,
            int toDefence, 
            int minExpected, 
            int maxExpected
            )
        {
            Entity entity = new Slime(5, fromDamage, 2, "", 1, 0);
        }
    }
}
