using EntityEngine.Entities;
using EntityEngine.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public class FireBall : ISkill
    {
        public void UseSkill(IEntity from, IEntity to)
        {
            if(from is not IMagical mage) throw new NotAllowedToUseSkill();
        }
    }
}
