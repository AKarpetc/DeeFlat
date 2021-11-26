using DeeFlat.Abstractions.Abstractions;
using System.Collections.Generic;

namespace DeeFlat.Course.Core.Domain
{
    public class Folder : BaseMDB
    {
        public virtual IList<File> Files { get; set; }
    }
}
