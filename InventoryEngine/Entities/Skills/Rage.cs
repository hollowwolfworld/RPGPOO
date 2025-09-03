using EntityEngine.Entities;
using EntityEngine.Entities.Players;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class Rage : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if (from is not Warrior) throw new NotAllowedToUseSkill();

            from.Status[Status.RAGE] = 2;
        }
    }
}
