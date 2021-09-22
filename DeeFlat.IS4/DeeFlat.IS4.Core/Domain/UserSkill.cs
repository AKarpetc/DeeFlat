using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeeFlat.IS4.Core.Domain
{
    public class UserSkill : BaseEntity
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public Guid SkilId { get; set; }

        public string SkilName { get; set; }

    }
}
