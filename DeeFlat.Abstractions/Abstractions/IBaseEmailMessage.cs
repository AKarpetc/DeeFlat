using System.Collections.Generic;

namespace DeeFlat.Abstractions.Abstractions
{
    public interface IBaseEmailMessage
    {
        public string Subject { get; set; }

        public IEnumerable<string> To { get; set; }
    }
}
