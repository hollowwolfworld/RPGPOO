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
        private Dictionary<IEntity, List<SkillLevel>> entitiesSkills;

        public EntityLevelupSkill()
        {
            entitiesSkills = new Dictionary<IEntity, List<SkillLevel>>
            {
                {
                    new Warrior(0, 0, 0, 0, 0, 0, 0, 0, "warrior"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new Rage())
                    }
                },
                {
                    new Sorcerer("sorcerer"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new FireBall()),
                        new SkillLevel(1, new Paralisy()),
                        new SkillLevel(1, new BuffPV()),
                    }
                },
                {
                    new Thieft(0, 0, 0, 0, 0, 0, 0, 0, "thieft"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel (1, new SneakAttack()),
                    }
                },
                {
                    new Skeleton(0, 0, 0, 0, 0, 0, 0, "skeleton"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new ShootAnArrow()),
                    }
                },
                {
                    new Wolf(0, 0, 0, 0, 0, 0, "wolf"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new Bite())
                    }
                },
                {
                    new Slime(0, 0, 0, 0, 0, 0, 0, 0, 0, "slime"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel(1, new DrainPV())
                    }
                },
                {
                    new Thugs(0, 0, 0, 0, 0, 0, 0, "thugs"),
                    new List<SkillLevel>()
                    {

                    }
                },
                {
                    new Wizzard(0, 0, 0, 0, 0, 0, 0, 0, 0, "wizzard"),
                    new List<SkillLevel>()
                    {
                        new SkillLevel (1, new BuffPV()),
                        new SkillLevel (1, new FireBall()),
                        new SkillLevel (1, new Paralisy()),
                    }
                },
            };
        }

        public ReadOnlyDictionary<IEntity, List<SkillLevel>> EntitiesSkill { get => new ReadOnlyDictionary<IEntity, List<SkillLevel>>(entitiesSkills); }
    }
}
