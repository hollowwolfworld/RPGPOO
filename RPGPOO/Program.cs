using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using EntityEngine.Entities.Skills;

namespace RPGPOO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new Warrior.Builder();
            var warior = builder
                .SetName("UwU")
                .SetGold(100)
                .SetLuck(500)
                .Build();


            var skills = LevelManager.GetSkillsForLevel(1, typeof(Warrior));

            skills.ForEach(sk => Console.WriteLine(sk.GetType()));
        }
    }
}