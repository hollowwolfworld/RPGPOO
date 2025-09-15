using EntityEngine;
using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightEngine
{
    public class Flee : Move
    {
        public IEntity Opponent { get; set; }

        public Flee(IEntity opponent)
        {
            this.Opponent = opponent;
        }
    }
}
