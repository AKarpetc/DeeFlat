using DeeFlat.Core.Domain.Base;
using DeeFlat.Core.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.Core.Domain
{
    public class UserGroup : BaseEntity
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid GroupId { get; set; }

        public virtual Group Group { get; set; }

    }
}
