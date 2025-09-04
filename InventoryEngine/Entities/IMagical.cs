using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities
{
    public interface IMagical
    {
        public int MaxManaPoint { get; protected set; }
        public int ManaPoint { get; set; }
    }
}
