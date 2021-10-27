using DeeFlat.Abstractions.Abstractions;
using System.Collections.Generic;

namespace DeeFlat.Course.Core.Domain
{
    public class Folder : BaseEntity
    {
        public virtual IList<File> Files { get; set; }
    }
}
