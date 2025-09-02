using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Exceptions
{
    public class NotEnoughtItem : Exception
    {
        public NotEnoughtItem()
        {
        }

        public NotEnoughtItem(string? message) : base(message)
        {
        }
    }
}
