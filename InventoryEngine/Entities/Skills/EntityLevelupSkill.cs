using EntityEngine.Entities.Enemies;
using EntityEngine.Entities.Players;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Skills
{
    public class EntityLevelupSkill
    {
        private Dictionary<string, List<SkillLevel>> entitiesSkills;

        public EntityLevelupSkill()
        {
            entitiesSkills = new Dictionary<string, List<SkillLevel>>
            {
                {
                    typeof(Warrior).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new Rage())
                    }
                },
                {
                    typeof(Sorcerer).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new FireBall()),
                        new SkillLevel(1, new Paralisy()),
                        new SkillLevel(1, new Heal()),
                    }
                },
                {
                    typeof(Thieft).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel (1, new SneakAttack()),
                    }
                },
                {
                    typeof(Skeleton).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new ShootAnArrow()),
                    }
                },
                {
                    typeof(Wolf).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new Bite())
                    }
                },
                {
                    typeof(Slime).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new DrainPV())
                    }
                },
                {
                    typeof(Thugs).ToString(),
                    new List<SkillLevel>()
                    {

                    }
                },
                {
                    typeof(Wizzard).ToString(),
                    new List<SkillLevel>()
                    {
                        new SkillLevel (1, new Heal()),
                        new SkillLevel (1, new FireBall()),
                        new SkillLevel (1, new Paralisy()),
                    }
                },
            };
        }

        public ReadOnlyDictionary<string, List<SkillLevel>> EntitiesSkill { get => new ReadOnlyDictionary<string, List<SkillLevel>>(entitiesSkills); }
    }
}
