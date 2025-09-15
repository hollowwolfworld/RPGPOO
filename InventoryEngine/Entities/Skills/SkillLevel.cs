using FightEngine.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Skills
{
    public class SkillLevel
    {
        private int level;
        private ISkill skill;

        public SkillLevel(int level, ISkill skill)
        {
            Level = level;
            Skill = skill;
        }

        public int Level { get { return level; } private set { level = value; } }
        public ISkill Skill { get { return skill; } private set { skill = value; } }
    }
}
