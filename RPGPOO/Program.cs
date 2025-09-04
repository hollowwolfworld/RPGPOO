using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using EntityEngine.Entities.Skills;

namespace RPGPOO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var skills = LevelManager.GetSkillsForLevel(1, new Warrior(0,0,0,0,0,0,0,0,""));

            skills.ForEach(sk => Console.WriteLine(sk.GetType()));
        }
    }
}