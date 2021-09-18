using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain.Base
{
    public class BaseAudit
    {
        public bool IsDeleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime Deleted { get; set; }
    }
}
