using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Abstractions.Exceptions
{
    public class CustomizedException : Exception
    {
        public CustomizedException(string message) : base(message)
        {
        }
    }

    public class EntityIsNotFoundException : CustomizedException
    {
        public EntityIsNotFoundException(string messge) : base(messge)
        {
        }
    }
}
