using EntityEngine.Entities.Skills;
using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public static class LevelManager
    {
        private static EntityLevelupSkill EntityLevelupSkill { get; set; } = new EntityLevelupSkill();
        public static int XPNeeded(int level) => Convert.ToInt32(Math.Round(75 * Math.Pow(level, 1.5)));
        public static List<ISkill> GetSkillsForLevel(int level, Type entity)
        {
            List<ISkill> skills = new List<ISkill>();
            var entitiesSkillsLevels = EntityLevelupSkill.EntitiesSkill;
            var entities = EntityLevelupSkill.EntitiesSkill.Keys.ToList().FindAll((key) => key == entity.ToString());

            foreach (var ent in entities)
            {
                var skillForLevel = entitiesSkillsLevels[ent.ToString()].FindAll((skillLevel => skillLevel.Level <= level)).Select((skillLevel) => skillLevel.Skill);
                skills.AddRange(skillForLevel);
            }

            return skills;
        }
    }
}
