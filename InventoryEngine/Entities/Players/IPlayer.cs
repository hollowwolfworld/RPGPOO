using EntityEngine.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Entities.Players
{
    public interface IPlayer: IEntity
    {
        public int XP { get; set; }
        public Inventory PlayerInventory { get; }

        public string Stats();
    }
}
