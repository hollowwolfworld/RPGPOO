using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Enemies
{
    public class Ennemy : Entity
    {
        protected Ennemy(int hp, int attack, int defence, int levels, string name) : base(hp, attack, defence, levels, name)
        {

        }
    }
}
