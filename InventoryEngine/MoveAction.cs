using EntityEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine
{
    public class MoveAction
    {
        public IEntity Target { get; set; }
        public Move Move { get; set; }

        public MoveAction(IEntity target, Move move)
        {
            Target = target;
            Move = move;
        }
    }
}
