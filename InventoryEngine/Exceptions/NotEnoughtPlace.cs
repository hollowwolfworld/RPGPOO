using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Exceptions
{
    public class NotEnoughtPlace : Exception
    {
        public NotEnoughtPlace()
        {
        }

        public NotEnoughtPlace(string? message) : base(message)
        {
        }
    }
}
