using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEngine.Exceptions
{
    public class ItemNotFound : Exception
    {
        public ItemNotFound()
        {
        }

        public ItemNotFound(string? message) : base(message)
        {
        }
    }
}
