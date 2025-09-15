using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityEngine.Exceptions
{
    public class NotAllowedToUseSkill : Exception
    {
        public NotAllowedToUseSkill()
        {
        }

        public NotAllowedToUseSkill(string? message) : base(message)
        {
        }
    }
}
