using EntityEngine.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities
{
    public interface IHumanoid
    {
        public Inventory Inventory { get; }
        public decimal Gold { get; set; }
    }
}
