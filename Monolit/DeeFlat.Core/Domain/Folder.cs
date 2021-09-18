using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class Folder : BaseEntity
    {
        public virtual IList<File> Files { get; set; }
    }
}
