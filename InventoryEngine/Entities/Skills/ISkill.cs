using EntityEngine;
using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine.Skills
{
    public interface ISkill : Move
    {
        public void UseSkill(IEntity from, IEntity to);
    }
}
