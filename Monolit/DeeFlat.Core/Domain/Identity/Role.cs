using DeeFlat.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual IList<UserRole> Users { get; set; }

    }
}
